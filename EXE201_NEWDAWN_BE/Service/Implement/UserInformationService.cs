using AutoMapper;
using BussinessObjects.Models;
using DTOS.Login;
using Repository.Interface;
using Service.Interface;
using System.Security.Cryptography;
using System.Text;

namespace Service.Implement
{
    public class UserInformationService : IUserInformationService
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public UserInformationService(IUserInformationRepository userInformationRepository, ITokenService tokenService, IMapper mapper) 
        {
            _mapper = mapper;
            _tokenService = tokenService;
            _userInformationRepository = userInformationRepository;
        }

        public async Task<UserDto> GetAccountLoginByUsername(LoginDto loginDto)
        {
            UserInformation user = await _userInformationRepository.GetAccountLoginByUsername(loginDto.Username);
            if (user == null || user.Status == 1) // status block
                return null;
            else
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i])
                    {
                        return null;
                    }
                }


                UserDto userDto = _mapper.Map<UserDto>(user);
                userDto.Token = _tokenService.CreateToken(user);
                return userDto;
            }
        }
    }
}
