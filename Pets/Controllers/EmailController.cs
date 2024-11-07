using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;  // 明確指定使用 MailKit 的 SmtpClient
using System.Threading.Tasks;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        // POST: api/Email
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
        {
            if (emailRequest == null || string.IsNullOrEmpty(emailRequest.To) ||
                string.IsNullOrEmpty(emailRequest.Subject) || string.IsNullOrEmpty(emailRequest.Body))
            {
                return BadRequest("請求內容不完整。");
            }

            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("系統通知", "your-email@example.com")); // 使用您發送電子郵件的帳號
                emailMessage.To.Add(new MailboxAddress("", emailRequest.To));
                emailMessage.Subject = emailRequest.Subject;
                emailMessage.Body = new TextPart("plain") { Text = emailRequest.Body };




                using (var client = new MailKit.Net.Smtp.SmtpClient()) // 明確指定使用 MailKit 的 SmtpClient
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync("endearingpetsworld@gmail.com", "gmip hhkk nksw vdxt"); // 使用您的帳號和密碼
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }

                return Ok("電子郵件已成功發送。");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"發送電子郵件時發生錯誤: {ex.Message}");
            }
        }
    }

    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
