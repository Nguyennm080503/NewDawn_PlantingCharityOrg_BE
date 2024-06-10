using AutoMapper;
using BussinessObjects.Models;
using DTOS.Account;
using DTOS.Login;
using DTOS.RegisterUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Org.BouncyCastle.Asn1.Cms;
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

        public async Task<UserDto> GetUserAccountByUserName(string username)
        {
            var result = await _userInformationRepository.GetAccountLoginByUsername(username);
            return _mapper.Map<UserDto>(result);
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

        public async Task<ProfileView> GetProfile(int accountID)
        {
            var profile = await _userInformationRepository.GetAccountById(accountID);
            return _mapper.Map<ProfileView>(profile);
        }

        public async Task<UserInformation> GetUserByAccount(int accountID)
        {
            return await _userInformationRepository.GetAccountById(accountID);
        }

        public async Task<bool> RegisterAccount(RequestRegisterUser userRegister)
        {
            using var hmac = new HMACSHA512();
            var newUserAccount = new UserInformation
            {
                Email = userRegister.Email,
                FullName = userRegister.FullName,
                RoleID = 2,
                Status = 0,
                PhoneNumber = userRegister.PhoneNumber,
                Username = userRegister.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegister.Password)),
                PasswordSalt = hmac.Key,
            };
            var result = await _userInformationRepository.RegisterAccount(newUserAccount);
            return result;
        }

        public async Task UpdateProfile(ProfileUpade profileUpade)
        {
            await _userInformationRepository.UpdateProfile(profileUpade);
        }

        public async Task UpdateStatusMemberAccount(StatusParams statusParams)
        {
            var user = _userInformationRepository.GetAccountById(statusParams.AccountID);
            user.Result.Status = statusParams.Status;
            await _userInformationRepository.UpdateStatusMemberAccount(user.Result);
        }

        public async Task<bool> ResetPassword(string username, string password)
        {
            var user = await GetUserByUserName(username);
            if (user == null) return false;
            var result = await _userInformationRepository.UpdatePasswordAccount(user.Username, password);
            return result;
        }

        public async Task<UserInformationView> GetUserByUserName(string username)
        {
            var userAccount = _userInformationRepository.GetListMemberUser().Result.Where(x => x.Username.Equals(username)).FirstOrDefault();
            if (userAccount == null) return null;
            return userAccount;
        }
    }
}
