using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSecretSanta.Models;
using AzureSecretSanta.Repository;
using AzureSecretSanta.Services.Interfaces;
using AutoMapper;
using AzureSecretSanta.Infrastructure;
using System.Linq;

namespace AzureSecretSanta.Services
{
    public class UserService : IUserService
    {
        private static IMapper _mapper = MappingProfile.InitializeAutoMapper().CreateMapper();
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<UserModel> AddNewUser(UserModel user)
        {
            var userDto = await this._userRepository.AddNewUser(_mapper.Map<UserDto>(user));
            return _mapper.Map<UserModel>(userDto);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var usersDto = await this._userRepository.GetAllUsers();
            return _mapper.Map<IEnumerable<UserModel>>(usersDto).ToList();
        }

        public async Task<List<UserModel>> GetAllUsersWithoutSanta()
        {
            var usersDto = await this._userRepository.GetAllUsersWithoutSanta();
            return _mapper.Map<IEnumerable<UserModel>>(usersDto).ToList();
        }

        public async Task UpdateUser(UserModel user)
        {
            this._userRepository.UpdateUser(_mapper.Map<UserDto>(user));
            await this._userRepository.Save();
        }
    }
}