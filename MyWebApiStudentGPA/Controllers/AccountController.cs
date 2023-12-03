using BEN.DTOs;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApiStudentGPA.Interfaces;

namespace MyWebApiStudentGPA.Controllers
{
    public class TokenVerifier
    {
        public string Token { get; set; }

        public string jwt { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ITokenServices _tokenServices;
        private readonly ILoginClass _loginClass;

        public AccountController(ILoginClass loginClass
                                )
        {
            _loginClass = loginClass;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var validLogin = await _loginClass.Login(loginDto);
            if (validLogin == null)

            {
                return Unauthorized("Invalid Email or Password");
            }
            else
                return Ok(validLogin);
        }


        [HttpPost("register")]
        public async Task<ActionResult<EmailConfirmationDto>> Register(RegisterDto registerDto)
        {

            var registerUser = await _loginClass.Register(registerDto);
            if (registerUser == null)

            {
                return BadRequest("Email already exist");
            }
            else
                return Ok(registerUser);
        }
    }
}
