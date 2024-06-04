using AutoMapper;
using BussinessObjects.Models;
using DAO;
using DTOS.Account;
using Repository.Interface;

namespace Repository.Implement
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private readonly IMapper mapper;

        public UserInformationRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }
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
                .ToList();
            return mapper.Map<IEnumerable<UserInformationView>>(users);
        }

        public async Task UpdateProfile(ProfileUpade profileUpade)
        {
            var profile = await UserInformationDAO.Instance.GetAccountById(profileUpade.AccountID);
            profile.PhoneNumber = profileUpade.PhoneNumber;
            profile.FullName = profileUpade.FullName;
            profile.Email = profileUpade.Email;
            await UserInformationDAO.Instance.UpdateAsync(profile);
        }

        public async Task UpdateStatusMemberAccount(UserInformation userInformation)
        {
            await UserInformationDAO.Instance.UpdateAsync(userInformation);
        }
    }
}
