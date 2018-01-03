using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSecretSanta.Interfaces.Services;
using AzureSecretSanta.Repository;
using AzureSecretSanta.Services.Interfaces;

namespace AzureSecretSanta.Services
{
    public class SecretSantaService : ISecretSantaService
    {
        private IUserRepository userRepository;
        private ISmtpService smtpService;

        public SecretSantaService(IUserRepository userRepository = null, ISmtpService smtpService = null)
        {
            this.userRepository = userRepository ?? new UserRepository();
            this.smtpService = smtpService ?? new SmtpService();
        }

        public async Task ShuffleUsers()
        {
            var users = await this.userRepository.GetAllUsersWithoutSanta();

            var pool = new List<int>();
            foreach (var user in users)
            {
                pool.Add(user.UserId);
            }

            var userIdWithoutSanta = pool[0];
            var index = 0;
            
            while (true)
            {
                var person = pool[index];
                pool.RemoveAt(index);

                if (pool.Count == 0)
                {
                    users.Find(u => u.UserId == person).SantaOf = users.Find(u => u.UserId == userIdWithoutSanta);
                    break;
                }

                var random = new Random().Next(pool.Count);
                users.Find(u => u.UserId == person).SantaOf = users.Find(u => u.UserId == pool[random]);
                index = random;
            }

            foreach (var user in users)
            {
                await this.smtpService.SendEmail(user, user.SantaOf);
            }

            await this.userRepository.UpdateUsers();
        }
    }
}