using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSecretSanta.Models;

namespace AzureSecretSanta.Repository
{
    public interface IUserRepository
    {
        Task<UserDto> AddNewUser(UserDto user);
        Task<List<UserDto>> GetAllUsers();
        Task Save();
        void UpdateUser(UserDto user);
        Task<List<UserDto>> GetAllUsersWithoutSanta();
    }
}
