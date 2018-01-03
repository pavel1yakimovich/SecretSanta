using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSecretSanta.Models;

namespace AzureSecretSanta.Repository
{
    public interface IUserRepository
    {
        Task<UserModel> AddNewUser(UserModel user);
        Task<List<UserModel>> GetAllUsers();
        Task UpdateUsers();
        Task<List<UserModel>> GetAllUsersWithoutSanta();
    }
}
