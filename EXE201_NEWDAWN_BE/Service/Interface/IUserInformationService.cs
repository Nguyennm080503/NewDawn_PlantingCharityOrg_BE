using DTOS.Login;

namespace Service.Interface
{
    public interface IUserInformationService
    {
        Task<UserDto> GetAccountLoginByUsername(LoginDto loginDto);
    }
}
