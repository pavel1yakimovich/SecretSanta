using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using AzureSecretSanta.Models;

namespace AzureSecretSanta.Repository
{
    public class UserRepository : IUserRepository
    {
        private SecretSanta db;

        public UserRepository(SecretSanta ctx = null)
        {
            this.db = ctx ?? new SecretSanta();
        }

        public async Task<UserModel> AddNewUser(UserModel user)
        {
            var saveduser = db.Users.Add(user);
            await db.SaveChangesAsync();

            return saveduser;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await db.Users.ToListAsync();

            return users;
        }

        public async Task UpdateUsers()
        {
            await db.SaveChangesAsync();
        }

        public async Task<List<UserModel>> GetAllUsersWithoutSanta()
        {
            var usersWithoutSanta = await db.Users.Where(u => u.SantaOf == null).ToListAsync();
            return usersWithoutSanta;
        }
    }
}