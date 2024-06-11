using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
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

        public async Task SendMailOTPAsync(IWebHostEnvironment webHostEnvironment, MailContent mailContent, string otp)
        {

            //var emailTemplatePath = Path.Combine(webHostEnvironment.ContentRootPath, "Template", "OTPEmailTemplate.cs");
            //var emailBody = await File.ReadAllTextAsync(emailTemplatePath);
            var emailBody = "<!DOCTYPE html> <html lang=\"en\"> <head> <meta charset=\"UTF-8\" /><title></title><style>body {margin: 0;padding: 0;font-family: \"Helvetica Neue\", Helvetica, Arial, sans-serif;color: #333;background-color: #fff;}.container {margin: 0 auto;width: 100%;max-width: 600px;padding: 0 0px;padding-bottom: 10px;border-radius: 5px;line-height: 1.8;}.header {border-bottom: 1px solid #eee;display: flex;}.img {margin-top: 20px;margin-left: 20px;}.header a {font-size: 1.4em;color: #000;text-decoration: none;font-weight: 600;}.content {min-width: 700px;overflow: auto;line-height: 2;}.otp {background: linear-gradient( to right, #00bc69 0, #00bc88 50%, #00bca8 100% );margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;}.footer {color: #aaa;font-size: 0.8em;line-height: 1;font-weight: 300;}.email-info {color: #666666;font-weight: 400;font-size: 13px;line-height: 18px;padding-bottom: 6px;}.email-info a {text-decoration: none;color: #00bc69;}</style></head><body><div class=\"container\"><div class=\"header\"><div class=\"img\"><img src=\"http://res.cloudinary.com/dqvkyhaet/image/upload/v1717525597/suvqwvivy3cvtom75dd6.png\" alt=\"LogoImage\" /></div><div><h1>Nuôi Cây</h1></div></div><br /><p>Chúng tôi đã nhận được yêu cầu đăng nhập vào tài khoản<strong> Nuôi cây</strong> của bạn. Vì mục đích bảo mật, vui lòng xác minh danh tính của bạn bằng cách cung cấp Mật khẩu một lần (OTP) sau đây.<br /><b>Mã xác minh Mật khẩu dùng một lần (OTP) của bạn là:</b></p><h2 class=\"otp\">@Insert.OTP</h2><p style=\"font-size: 0.9em\"><strong>Mật khẩu dùng một lần (OTP) có hiệu lực trong 3 phút.</strong><br /><br />Nếu bạn không bắt đầu yêu cầu đăng nhập này, vui lòng bỏ qua thông báo này. Vui lòng đảm bảo tính bảo mật của OTP của bạn và không chia sẻ nó với bất kỳ ai. Không chuyển tiếp hoặc đưa mã này cho bất kỳ ai.<br /><strong>Không chuyển tiếp hoặc đưa mã này cho bất kỳ ai.</strong><br /><br /><strong>Cảm ơn bạn đã sử dụng Nuôi cây.</strong><br /><br />Trân trọng,<br /><strong>Nuoi Cay Group</strong></p><hr style=\"border: none; border-top: 0.5px solid #131111\" /><div class=\"footer\"><p>This email can't receive replies.</p></div></div></body></html>";
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

        //public string HashOTP(string otp)
        //{
        //    using (SHA256 sha256 = SHA256.Create())
        //    {
        //        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(otp));
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2"));
        //        }
        //        return builder.ToString();
        //    }
        //}

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
