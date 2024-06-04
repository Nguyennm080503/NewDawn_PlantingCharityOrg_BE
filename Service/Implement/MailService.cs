using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Service.Interface;
using Service.Mail;
using System.Security.Cryptography;
using System.Text;

namespace Service.Implement
{
    public class MailService : IMailService
    {
        private MailSetting _mailSetting { get; set; }
        public MailService(IOptions<MailSetting> options)
        {
            _mailSetting = options.Value;
        }

        public async Task SendMailOTPAsync(MailContent mailContent, string otp)
        {
            var emailTemplatePath = Path.Combine(Directory.GetCurrentDirectory(), "Template", "OTPEmailTemplate.cs");
            var emailBody = await File.ReadAllTextAsync(emailTemplatePath);
            emailBody = emailBody.Replace("@Insert.OTP", otp);


            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail);
            email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail));
            email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
            email.Subject = mailContent.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = emailBody;
            email.Body = builder.ToMessageBody();

            using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtpClient.Connect(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(_mailSetting.Mail, _mailSetting.Password);
                smtpClient.Send(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            smtpClient.Disconnect(true);
        }

        public string HashOTP(string otp)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(otp));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail);
            email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Mail));
            email.To.Add(new MailboxAddress(mailContent.To, mailContent.To));
            email.Subject = mailContent.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtpClient.Connect(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(_mailSetting.Mail, _mailSetting.Password);
                smtpClient.Send(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            smtpClient.Disconnect(true);
        }


    }
}
