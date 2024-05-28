using BussinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class UserInformationDAO : BaseDAO<UserInformation>
    {
        private static UserInformationDAO instance = null;
        private readonly DataContext dataContext;

        private UserInformationDAO()
        {
            dataContext = new DataContext();
        }

        public static UserInformationDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInformationDAO();
                }
                return instance;
            }
        }

        public async Task<UserInformation> GetAccountById(int id)
        {
            return await dataContext.UserInformation.FirstOrDefaultAsync(x => x.AccountID == id);
        }

        public async Task<UserInformation> GetAccountLoginByUsername(string username)
        {
            return await dataContext.UserInformation.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
