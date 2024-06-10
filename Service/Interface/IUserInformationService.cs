using BussinessObjects.Models;
using DTOS.Account;
using DTOS.Login;
using DTOS.RegisterUser;
namespace Service.Interface
{
    public interface IUserInformationService
    {
        Task<UserDto> GetAccountLoginByUsername(LoginDto loginDto);
        Task<IEnumerable<UserInformationView>> GetListMemberUser();
        Task UpdateStatusMemberAccount(StatusParams statusParams);
        Task<UserInformation> GetUserByAccount(int accountID);
        Task<ProfileView> GetProfile(int accountID);
        Task UpdateProfile(ProfileUpade profileUpade);
        Task<bool> RegisterAccount(RequestRegisterUser userRegister);
        Task<UserDto> GetUserAccountByUserName(string username);
        Task CreateAccount(AccountCreate account);
        Task<UserDto> GetAccountLoginByAdminPermission(LoginDto loginDto);
    }
}
