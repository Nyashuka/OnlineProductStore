using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineProductStore.Server.DTO;
using OnlineProductStore.Server.Services.Users;

namespace OnlineProductStore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> UserRegistration(UserRegistrationDTO userRegistration)
        {
            var result = await _userService.RegisterNewUserAsync(userRegistration);
            if (result.IsUserRegistered)
            {
                return Ok(result.Message);
            }

            ModelState.AddModelError("Email", result.Message);
            return BadRequest(ModelState);
        }

        [HttpGet("unique-user-email")]
        public IActionResult CheckUniqueUserEmail(string email)
        {
            var result = _userService.CheckIsUniqueEmail(email);
            return Ok(result);
        }

        [HttpGet("get-all")]
        public IActionResult GetAllUsers()
        {        
            return Ok(_userService.GetAllUsers());
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDTO payload)
        {
            var result = await _userService.LoginAsync(payload);
            if (result.IsLoginSuccess)
            {
                return Ok(result.TokeResponse);
            }
            ModelState.AddModelError("LoginError", "Invalid Credentials");
            return BadRequest(ModelState);
        }
    }
}
