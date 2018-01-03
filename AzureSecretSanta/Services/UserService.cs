using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSecretSanta.Models;
using AzureSecretSanta.Repository;
using AzureSecretSanta.Services.Interfaces;

namespace AzureSecretSanta.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository userRepository = null)
        {
            this.userRepository = userRepository ?? new UserRepository();
        }

        public async Task<UserModel> AddNewUser(UserModel user) => await userRepository.AddNewUser(user);

        public async Task<List<UserModel>> GetAllUsers() => await userRepository.GetAllUsers();
    }
}