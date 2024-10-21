using Jwt.Data;
using Jwt.Dto;
using Jwt.Entities;
using Jwt.Services;
using Jwt.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jwt.Managers
{
    public class UserManagerService : IUserAdd
    {
        // Dependency ınjection for the our View Model
        private readonly JwtContext _jwtContext;
        private readonly TokenService _tokenService;


        public UserManagerService(JwtContext jwtContext, TokenService tokenService)
        {
            _jwtContext = jwtContext;
            _tokenService = tokenService;
        }

        // Create service 
        public async Task<IActionResult> UserAdd(UserDto userDto)
        {
            var user = new UserEntity
            {
                Password = userDto.Password,
                Email = userDto.Email
            };
            _jwtContext.Add(user);// add db with context 
            var result = await _jwtContext.SaveChangesAsync();


            if (result > 0)
            {
                return new OkObjectResult("Create User Sucsess.");
            }
            else
            {
                return new BadRequestObjectResult(result.ToString());
            }
        }



        // Login Service for the our Login validation
        public async Task<string> Login(string email, string password)
        {
            var user = await _jwtContext.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user == null || user.Password != password)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            // Create Token
            var token = _tokenService.GenerateToken(user);
            return token;
        }
    }


}

