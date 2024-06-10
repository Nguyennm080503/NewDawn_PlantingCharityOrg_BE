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
using System;
using Microsoft.AspNetCore.Authorization;

namespace EXE201_NEWDAWN_BE.Controllers.RegisterController
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : BaseApiController
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

        [HttpPost("send-email-otp-reset-password")]
        public async Task<IActionResult> SendEmailOTPResetPassword(string username)
        {
            try
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
                var userExisted = await _userInformationService.GetUserByUserName(username);
                if (userExisted == null) return BadRequest("Username is not existed, please try again!");
                await _mailService.SendMailOTPAsync(_webHostEnvironment, new Service.Mail.MailContent
                {
                    To = userExisted.Email,
                    Subject = "Nuôi cây",
                    Body = ""
                }, otp);
                return Ok(otptoken);
            }
            catch
            {
                return BadRequest(new ApiResponseStatus(400, "Exception when excuting in server!"));
            }

        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(string username, string password)
        {
            try
            {
                var result = await _userInformationService.ResetPassword(username.Trim(), password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseStatus(500, ex.Message));
            }
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(string password)
        {
            try
            {
                var userIdLogIn = GetLoginAccountId();
                var userExisted = await _userInformationService.GetUserByAccount(userIdLogIn);
                if (userExisted == null) return BadRequest(new ApiResponseStatus(400, "Exception when excuting in server!"));
                var result = await _userInformationService.ResetPassword(userExisted.Username, password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponseStatus(500, ex.Message));
            }
        }

    }
}