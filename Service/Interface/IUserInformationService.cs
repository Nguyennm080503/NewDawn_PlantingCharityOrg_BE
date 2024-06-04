using DTOS.Account;
using DTOS.Login;

namespace Service.Interface
{
    public interface IUserInformationService
    {
        Task<UserDto> GetAccountLoginByUsername(LoginDto loginDto);
        Task<IEnumerable<UserInformationView>> GetListMemberUser();
        Task UpdateStatusMemberAccount(StatusParams statusParams);
    }
}
