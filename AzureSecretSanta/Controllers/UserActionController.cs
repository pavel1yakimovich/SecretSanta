using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AzureSecretSanta.Infrastructure;
using AzureSecretSanta.Interfaces.Services;
using AzureSecretSanta.Models;
using AzureSecretSanta.Services;
using AzureSecretSanta.Services.Interfaces;
using AzureSecretSanta.ViewModels;

namespace AzureSecretSanta.Controllers
{
    public class UserActionController : ApiController
    {
        private IUserService userService;
        private ISecretSantaService secretSantaService;

        public UserActionController(IUserService userService, ISecretSantaService secretSantaService)
        {
            this.userService = userService;
            this.secretSantaService = secretSantaService;
        }

        public UserActionController()
        {
            this.userService = new UserService();
            this.secretSantaService = new SecretSantaService();
        }

        [HttpPost]
        [ActionName("registerNewUser")]
        public async Task<IHttpActionResult> AddToSecretSantaList([FromBody] CreateUserViewModel newUser)
        {
            UserModel user = newUser.CreateUserViewModelToUser();

            user = await userService.AddNewUser(user);

            return Ok(user);
        }

        [ActionName("getAllUsers")]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            var users = await userService.GetAllUsers();

            var userViewModels = users.Select(u => u.UserModelToUserViewModel()).ToList();

            return Ok(userViewModels);
        }
        
        [HttpPost]
        [ActionName("shuffleUsers")]
        public async Task<IHttpActionResult> ShuffleUsers()
        {
            await secretSantaService.ShuffleUsers();

            return Ok();
        }
    }
}
