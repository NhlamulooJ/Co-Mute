using Co_muteAPI.Services.Users;
using Co_MuteDB.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Co_muteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public IConfiguration _configuration;
        private readonly IUserService _userService;
        public UsersController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        //Endpoint to save a user object to the database
        [HttpPost]
        [Route("Save")]
        public async Task<ActionResult> Save(User user)
        {
            var result = await _userService.Save(user);
            return Ok(result);
        }

        //Endpoint to login
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(string email, string password)
        {
            var result = await _userService.Login(email, password);
            return Ok(result);
        }

        //Endpoint to update user
        [HttpPost]
        [Route("Update")]
        public async Task<ActionResult> Update(User user)
        {
            var result = await _userService.Update(user);
            return Ok(result);
        }

        //Endpoint to get user by Id
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult> GetById(int Id)
        {
            var result = await _userService.GetById(Id);
            return Ok(result);
        }
    }
}
