using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using AzureSecretSanta.Models;
using AzureSecretSanta.Repository;
using AzureSecretSanta.Services;
using AzureSecretSanta.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace AzureSecretSanta.Tests
{
    [TestClass]
    public class SecretSantaServiceTests
    {
        [TestMethod]
        public async Task ShuffleUsersTest()
        {
            var mockedSmtpService = Substitute.For<ISmtpService>();
            mockedSmtpService.SendEmail(new UserModel(), new UserModel()).ReturnsForAnyArgs(Task.CompletedTask);

            var mockedRepository = Substitute.For<IUserRepository>();
            var users = new List<UserModel>
            {
                new UserModel {UserId = 1},
                new UserModel {UserId = 2},
                new UserModel {UserId = 3},
                new UserModel {UserId = 4},
            };

            mockedRepository.GetAllUsersWithoutSanta().ReturnsForAnyArgs(users);
            mockedRepository.UpdateUsers().ReturnsForAnyArgs(Task.CompletedTask);

            var service = new SecretSantaService(mockedRepository, mockedSmtpService);

            await service.ShuffleUsers();

            foreach (var user in users)
            {
                Assert.IsTrue(user.SantaOf?.UserId != user.UserId);
            }
        }
    }
}
