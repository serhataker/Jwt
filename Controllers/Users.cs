using Jwt.Dto;
using Jwt.Managers;
using Jwt.Services;
using Jwt.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly UserManagerService _userAddService;
        private readonly TokenService _tokenService;

        // we create the our user controlservice
        public Users(UserManagerService userAddService, TokenService tokenService)
        {
            _userAddService = userAddService;
            _tokenService = tokenService;
        }



        // Create User
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] UserView userView)
        {
            var userDto = new UserDto
            {
                Email = userView.Email,
                Password = userView.Password
            };

            var result = await _userAddService.UserAdd(userDto);



                return Ok(result);
        }

      // Validate User With Token
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginView loginView)
        {
            try
            {
                var token = await _userAddService.Login(loginView.Email, loginView.Password);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { Message = "Invalid email or password." });
            }
        }



    }
}
