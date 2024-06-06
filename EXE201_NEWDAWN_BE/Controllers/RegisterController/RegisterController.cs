using DTOS.Login;
using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using Org.BouncyCastle.Crypto;
using Microsoft.AspNetCore.Hosting;
using DTOS.RegisterUser;
using DTOS;

namespace EXE201_NEWDAWN_BE.Controllers.RegisterController
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMailService _mailService;
        private readonly IUserInformationService _userInformationService;
        private readonly ITokenService _tokenService;
        public RegisterController(IWebHostEnvironment webHostEnvironment, IUserInformationService userInformationService, IMailService mailService, ITokenService tokenService)
        {
            _webHostEnvironment = webHostEnvironment;
            _mailService = mailService;
            _userInformationService = userInformationService;
            _tokenService = tokenService;
        }

        [HttpPost("send-email-verification-code")]
        public async Task<IActionResult> VerifyEmail(string email)
        {
            Random random = new Random();
            string otp = "";

            for (int i = 0; i < 6; i++)
            {
                otp += random.Next(0, 10); // Số ngẫu nhiên từ 0 đến 9
            }
            var tokenOTP = new TokenOTP();
            tokenOTP.OTP = otp;
            var otptoken = _tokenService.CreateTokenOTP(tokenOTP);

            await _mailService.SendMailOTPAsync(_webHostEnvironment, new Service.Mail.MailContent
            {
                To = email,
                Subject = "Nuôi cây",
                Body = ""
            }, otp);
            return Ok(otptoken);
        }

        [HttpPost()]
        public async Task<IActionResult> register(RequestRegisterUser userRegister)
        {
            var existedUserAccount = await _userInformationService.GetUserAccountByUserName(userRegister.Username);
            if (existedUserAccount != null) 
            {
                return BadRequest("Username is existed");
            }
            var result = await _userInformationService.RegisterAccount(userRegister);
            return Ok(result);
        }


    }
}
