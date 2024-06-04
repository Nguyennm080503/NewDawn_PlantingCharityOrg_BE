using Service.Mail;

namespace Service.Interface
{
    public interface IMailService
    {
        Task SendMailAsync(MailContent mailContent, string otp);
        string HashOTP(string otp);
    }
}
