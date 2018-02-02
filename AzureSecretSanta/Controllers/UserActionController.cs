using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AzureSecretSanta.Infrastructure;
using AzureSecretSanta.Models;
using AzureSecretSanta.Services.Interfaces;
using AzureSecretSanta.ViewModels;
using AutoMapper;
using System.Collections.Generic;

namespace AzureSecretSanta.Controllers
{
    public class UserActionController : ApiController
    {
        private IUserService _userService;
        private ISecretSantaService _secretSantaService;
        private static IMapper _mapper = MappingProfile.InitializeAutoMapper().CreateMapper();

        public UserActionController(IUserService userService, ISecretSantaService secretSantaService)
        {
            this._userService = userService;
            this._secretSantaService = secretSantaService;
        }

        //public UserActionController()
        //{
        //    this._userService = new UserService();
        //    this._secretSantaService = new SecretSantaService();
        //}

        [HttpPost]
        [ActionName("registerNewUser")]
        public async Task<IHttpActionResult> AddToSecretSantaList([FromBody] CreateUserViewModel newUser)
        {
            UserModel user = _mapper.Map<UserModel>(newUser);

            user = await _userService.AddNewUser(user);

            return Ok(user);
        }

        [ActionName("getAllUsers")]
        public async Task<IHttpActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            var userViewModels = _mapper.Map<IEnumerable<UserViewModel>>(users).ToList();

            return Ok(userViewModels);
        }
        
        [HttpPost]
        [ActionName("shuffleUsers")]
        public async Task<IHttpActionResult> ShuffleUsers()
        {
            await _secretSantaService.ShuffleUsers();

            return Ok();
        }
    }
}
