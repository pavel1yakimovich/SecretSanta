using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSecretSanta.Interfaces.Services;
using AzureSecretSanta.Services.Interfaces;
using System.Linq;

namespace AzureSecretSanta.Services
{
    public class SecretSantaService : ISecretSantaService
    {
        private IUserService _userService;
        private ISmtpService _smtpService;

        public SecretSantaService(IUserService userService = null, ISmtpService smtpService = null)
        {
            this._userService = userService ?? new UserService();
            this._smtpService = smtpService ?? new SmtpService();
        }

        public async Task ShuffleUsers()
        {
            var users = await this._userService.GetAllUsersWithoutSanta();

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
                    users.Find(u => u.UserId == person).SantaOf = users.First(u => u.UserId == userIdWithoutSanta);
                    break;
                }

                var random = new Random().Next(pool.Count);
                users.Find(u => u.UserId == person).SantaOf = users.Find(u => u.UserId == pool[random]);
                index = random;
            }

            foreach (var user in users)
            {
                await this._smtpService.SendEmail(user, user.SantaOf);
            }

            users.Select(async u => await this._userService.UpdateUser(u));
        }
    }
}