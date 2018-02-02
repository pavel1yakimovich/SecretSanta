using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSecretSanta.Models;

namespace AzureSecretSanta.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> AddNewUser(UserModel user);
        Task<List<UserModel>> GetAllUsers();
        Task<List<UserModel>> GetAllUsersWithoutSanta();
        Task UpdateUser(UserModel user);
    }
}
