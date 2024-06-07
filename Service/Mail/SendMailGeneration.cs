using System.Text;

namespace Service.Mail
{
    public class SendMailGeneration
    {
        public static MailContent SendMailGenerationPlantCode(string toEmail, List<string> plantCodes)
        {
            var mailContext = new MailContent();
            mailContext.To = "nguyencanqn123@gmail.com";
            mailContext.Subject = "HỆ THỐNG XIN GỬI MÃ CODE CÂY SAU KHI THANH TOÁN";
            var bodyBuilder = new StringBuilder();
            bodyBuilder.AppendLine("<!DOCTYPE html>");
            bodyBuilder.AppendLine("<html lang='en'>");
            bodyBuilder.AppendLine("<head>");
            bodyBuilder.AppendLine("<meta charset='UTF-8' />");
            bodyBuilder.AppendLine("<title>Nuôi Cây</title>");
            bodyBuilder.AppendLine("<style>");
            bodyBuilder.AppendLine("body {margin: 0; padding: 0; font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif; color: #333; background-color: #fff;}");
            bodyBuilder.AppendLine(".container {margin: 0 auto; width: 100%; max-width: 600px; padding: 0 0px; padding-bottom: 10px; border-radius: 5px; line-height: 1.8;}");
            bodyBuilder.AppendLine(".header {border-bottom: 1px solid #eee; display: flex;}");
            bodyBuilder.AppendLine(".img {margin-top: 20px; margin-left: 20px;}");
            bodyBuilder.AppendLine(".header a {font-size: 1.4em; color: #000; text-decoration: none; font-weight: 600;}");
            bodyBuilder.AppendLine(".content {min-width: 700px; overflow: auto; line-height: 2;}");
            bodyBuilder.AppendLine(".otp {background: linear-gradient(to right, #00bc69 0, #00bc88 50%, #00bca8 100%); margin: 0 auto; width: max-content; padding: 0 10px; color: #fff; border-radius: 4px;}");
            bodyBuilder.AppendLine(".footer {color: #aaa; font-size: 0.8em; line-height: 1; font-weight: 300;}");
            bodyBuilder.AppendLine(".email-info {color: #666666; font-weight: 400; font-size: 13px; line-height: 18px; padding-bottom: 6px;}");
            bodyBuilder.AppendLine(".email-info a {text-decoration: none; color: #00bc69;}");
            bodyBuilder.AppendLine("</style>");
            bodyBuilder.AppendLine("</head>");
            bodyBuilder.AppendLine("<body>");
            bodyBuilder.AppendLine("<div class='container'>");
            bodyBuilder.AppendLine("<div class='header'>");
            bodyBuilder.AppendLine("<div class='img'>");
            bodyBuilder.AppendLine("<img src='http://res.cloudinary.com/dqvkyhaet/image/upload/v1717525597/suvqwvivy3cvtom75dd6.png' alt='LogoImage' />");
            bodyBuilder.AppendLine("</div>");
            bodyBuilder.AppendLine("<div>");
            bodyBuilder.AppendLine("<h1>Nuôi Cây</h1>");
            bodyBuilder.AppendLine("</div>");
            bodyBuilder.AppendLine("</div>");
            bodyBuilder.AppendLine("<br />");

            bodyBuilder.AppendLine("<p>Thân chào bạn,</p>");
            bodyBuilder.AppendLine("<p>Nhóm xin cảm ơn bạn đã góp 1 phần công sức cho dự án</p>");

            foreach (var code in plantCodes)
            {
                bodyBuilder.AppendLine($"<p>Mã cây của bạn là {code} <span> - Trạng thái : Hạt giống</span></p>");
            }

            bodyBuilder.AppendLine("<p>Chúc bạn có 1 ngày tốt lành!</p>");

            bodyBuilder.AppendLine("<hr style='border: none; border-top: 0.5px solid #131111' />");
            bodyBuilder.AppendLine("<div class='footer'>");
            bodyBuilder.AppendLine("<p>This email can't receive replies.</p>");
            bodyBuilder.AppendLine("</div>");
            bodyBuilder.AppendLine("</div>");
            bodyBuilder.AppendLine("</body>");
            bodyBuilder.AppendLine("</html>");

            mailContext.Body = bodyBuilder.ToString();
            return mailContext;
        }
    }
}
