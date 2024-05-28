using BussinessObjects.Models;
using DAO;
using DTOS.Account;
using Repository.Interface;

namespace Repository.Implement
{
    public class UserInformationRepository : IUserInformationRepository
    {
        public async Task<UserInformation> GetAccountById(int id)
        {
            return await UserInformationDAO.Instance.GetAccountById(id);
        }

        public async Task<UserInformation> GetAccountLoginByUsername(string email)
        {
            var user = await UserInformationDAO.Instance.GetAccountLoginByUsername(email);
            return user;
        }

        public async Task<IEnumerable<UserInformationView>> GetListMemberUser()
        {
            var users = UserInformationDAO.Instance.GetAllAsync().Result
                .Where(x => x.RoleID == 2)
                .Select(y => new UserInformationView
                {
                    AccountID = y.AccountID,
                    Email = y.Email,
                    FullName = y.FullName,
                    PhoneNumber = y.PhoneNumber,
                    Username = y.Username,
                    Status = y.Status
                }).ToList();
            return users;
        }

        public async Task UpdateStatusMemberAccount(UserInformation userInformation)
        {
            await UserInformationDAO.Instance.UpdateAsync(userInformation);
        }
    }
}
