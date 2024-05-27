using BussinessObjects.Models;
using DAO;
using Repository.Interface;

namespace Repository.Implement
{
    public class UserInformationRepository : IUserInformationRepository
    {
        public async Task<UserInformation> GetAccountLoginByUsername(string email)
        {
            var user = await UserInformationDAO.Instance.GetAccountLoginByUsername(email);
            return user;
        }
    }
}
