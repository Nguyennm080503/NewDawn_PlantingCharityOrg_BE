using BussinessObjects.Models;
using DTOS.Account;

namespace Repository.Interface
{
    public interface IUserInformationRepository
    {
        Task<UserInformation> GetAccountLoginByUsername(string email);
        Task<IEnumerable<UserInformationView>> GetListMemberUser();
        Task<UserInformation> GetAccountById(int id);
        Task UpdateStatusMemberAccount(UserInformation userInformation);
        Task UpdateProfile(ProfileUpade profileUpade);
    }
}
