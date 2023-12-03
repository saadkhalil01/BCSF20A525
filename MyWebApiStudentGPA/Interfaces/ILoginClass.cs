using BEN.DTOs;

namespace MyWebApiStudentGPA.Interfaces
{
    public interface ILoginClass
    {
        Task<UserDto> Login(LoginDto loginDto);
        Task<EmailConfirmationDto> Register(RegisterDto registerDto);
    }
}
