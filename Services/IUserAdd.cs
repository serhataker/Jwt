using Jwt.Dto;
using Jwt.ViewModel;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// our Class Interfaces

namespace Jwt.Services
{
    public interface IUserAdd
    {
       Task<IActionResult> UserAdd(UserDto userDto);
       Task<string> Login(string email, string password);

    }

}
