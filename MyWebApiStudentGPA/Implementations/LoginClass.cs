using BEN.DTOs;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using MyWebApiStudentGPA.Interfaces;

namespace MyWebApiStudentGPA.Implementations
{
    public class LoginClass : ILoginClass
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ITokenServices _tokenServices;

        public LoginClass(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 RoleManager<AppRole> roleManager,
                                 ITokenServices tokenServices
                                )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenServices = tokenServices;
            _roleManager = roleManager;
        }
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);


                if (user == null)
                {
                    return null;
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
                if (!result.Succeeded)
                {
                    return null;
                }

                return new UserDto
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = await _tokenServices.CreateToken(user),
                    DisplayName = user.DisplayName,
                    ProfilePicturUrl = user.ProfilPicture,
                    RefreshToken = ""
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EmailConfirmationDto> Register(RegisterDto registerDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(registerDto.Email);
                if (user != null)
                {
                    return null;
                }

                var Appuser = new AppUser()
                {
                    Email = registerDto.Email,
                    DisplayName = registerDto.DisplayName,
                    Gender = "",
                    TwoFactorEnabled = false,
                    ProfilPicture = "",
                    UserName = registerDto.Email
                };

                var result = await _userManager.CreateAsync(Appuser, registerDto.Password);

                if (!result.Succeeded)
                {

                    return null;
                }
                return new EmailConfirmationDto
                {
                    Email = Appuser.Email,
                    UserName = Appuser.UserName,
                    DisplayName = Appuser.DisplayName,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
