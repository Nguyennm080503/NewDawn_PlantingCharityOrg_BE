using AutoMapper;
using BussinessObjects.Models;
using DTOS.Account;
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

        public async Task<IEnumerable<UserInformationView>> GetListMemberUser()
        {
            var users = await _userInformationRepository.GetListMemberUser();
            return users;
        }

        public async Task<UserInformation> GetUserByAccount(int accountID)
        {
            return await _userInformationRepository.GetAccountById(accountID);
        }

        public async Task UpdateStatusMemberAccount(StatusParams statusParams)
        {
            var user = _userInformationRepository.GetAccountById(statusParams.AccountID);
            user.Result.Status = statusParams.Status;
            await _userInformationRepository.UpdateStatusMemberAccount(user.Result);
        }
    }
}
