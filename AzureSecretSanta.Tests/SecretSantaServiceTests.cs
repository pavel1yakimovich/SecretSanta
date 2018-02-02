using System.Collections.Generic;
using System.Threading.Tasks;
using AzureSecretSanta.Models;
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

            var mockedUserService = Substitute.For<IUserService>();
            var users = new List<UserModel>
            {
                new UserModel {UserId = 1},
                new UserModel {UserId = 2},
                new UserModel {UserId = 3},
                new UserModel {UserId = 4},
            };

            mockedUserService.GetAllUsersWithoutSanta().ReturnsForAnyArgs(users);

            var service = new SecretSantaService(mockedUserService, mockedSmtpService);

            await service.ShuffleUsers();

            foreach (var user in users)
            {
                Assert.IsTrue(user.SantaOf?.UserId != user.UserId);
            }
        }
    }
}
