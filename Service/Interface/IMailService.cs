using Microsoft.AspNetCore.Hosting;
using Service.Mail;

namespace Service.Interface
{
    public interface IMailService
    {
        Task SendMailOTPAsync(IWebHostEnvironment webHostEnvironment, MailContent mailContent, string otp);
        //string HashOTP(string otp);
        void SendMail(MailContent mailContent);
    }
}
