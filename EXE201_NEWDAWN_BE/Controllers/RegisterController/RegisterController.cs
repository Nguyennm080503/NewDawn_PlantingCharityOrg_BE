using DTOS.Login;
using HostelManagementWebAPI.MessageStatusResponse;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using Org.BouncyCastle.Crypto;

namespace EXE201_NEWDAWN_BE.Controllers.RegisterController
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IMailService _mailService;
        private readonly IUserInformationService _userInformationService;
        public RegisterController(IUserInformationService userInformationService, IMailService mailService)
        {
            _mailService = mailService;
            _userInformationService = userInformationService;
        }

        [HttpPost("/verify-email")]
        public async Task<IActionResult> VerifyEmail(string email)
        {
            Random random = new Random();
            string otp = "";

            for (int i = 0; i < 6; i++)
            {
                otp += random.Next(0, 10); // Số ngẫu nhiên từ 0 đến 9
            }
            var otpHashSHA256 = _mailService.HashOTP(otp);

            await _mailService.SendMailOTPAsync(new Service.Mail.MailContent
            {
                To = email,
                Subject = "Nuôi cây",
                Body = otp
            }, otp);
            return Ok(otpHashSHA256);
        }



    }
}
