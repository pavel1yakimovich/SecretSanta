using AzureSecretSanta.Models;
using AzureSecretSanta.ViewModels;

namespace AzureSecretSanta.Infrastructure
{
    public static class Mappers
    {
        public static UserModel CreateUserViewModelToUser(this CreateUserViewModel cuvm) =>
            new UserModel {Name = cuvm.Name, Email = cuvm.Email, GiftDescription = cuvm.GiftDescription};

        public static UserViewModel UserModelToUserViewModel(this UserModel um) => new UserViewModel
        {
            Name = um.Name,
            GiftDescription = um.GiftDescription,
            SantaOf = um.SantaOf?.UserId,
            UserId = um.UserId
        };
    }
}