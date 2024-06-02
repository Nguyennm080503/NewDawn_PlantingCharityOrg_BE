using BussinessObjects.Models;

namespace Service.Interface
{
    public interface ITokenService
    {
        string CreateToken(UserInformation user);
    }
}
