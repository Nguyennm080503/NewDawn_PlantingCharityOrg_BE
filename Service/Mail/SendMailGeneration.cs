using System.Text;

namespace Service.Mail
{
    public class SendMailGeneration
    {
        public static MailContent SendMailGenerationPlantCode(string toEmail, List<string> plantCodes)
        {
            var mailContext = new MailContent();
            mailContext.To = "nguyencanqn123@gmail.com";
            mailContext.Subject = "HỆ THÓNG XIN GỬI MÃ CODE CÂY SAO KHI THANH TOÁN";
            var bodyBuilder = new StringBuilder();
            bodyBuilder.AppendLine("<div style='text-align: center;'>");
            bodyBuilder.AppendLine($"<img src='https://res.cloudinary.com/dqpsvl3nu/image/upload/v1717465283/49e989c7-b011-4aa9-976b-9966029097f5_k0cutd.jpg' alt='Image' style='max-width: 100%; height: auto;' />");
            bodyBuilder.AppendLine("</div>");
            bodyBuilder.AppendLine("<p>Thân chào bạn,</p>");
            bodyBuilder.AppendLine("<p>Nhóm xin cảm ơn bạn đã góp 1 phần công sức cho dự án</p>");

            foreach (var code in plantCodes)
            {
                bodyBuilder.AppendLine($"<p>Mã cây của bạn là {code} <span> - Trạng thái : Hạt giống</span></p>");
            }

            bodyBuilder.AppendLine("<p>Chúc bạn có 1 ngày tốt lành!</p>");

            mailContext.Body = bodyBuilder.ToString();
            return mailContext;
        }
    }
}
