using BussinessObjects.Models;
using DTOS;

namespace Service.Interface
{
    public interface ITokenService
    {
        string CreateToken(UserInformation user);
        string CreateTokenOTP(TokenOTP tokenOTP);
    }
}
