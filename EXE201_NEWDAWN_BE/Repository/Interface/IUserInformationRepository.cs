using BussinessObjects.Models;

namespace Repository.Interface
{
    public interface IUserInformationRepository
    {
        Task<UserInformation> GetAccountLoginByUsername(string email);
    }
}
