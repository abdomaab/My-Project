using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmail.Dto;
using SendEmail.Service;

namespace SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;
        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest dto)
        {

            await _mailService.SendEmailAsync(dto.ToEmail, dto.Subject, dto.Body, dto.Attachments);
            return Ok();
        }

        /*[HttpPost("welcom")]
        public async Task<IActionResult> SendWelcomeEmail([FromBody]WelcomeRequest dto)
        {
            var filePth = $"{Directory.GetCurrentDirectory()}\\Template";// path of Template Folder
            var str = new StreamReader(filePth);

            var mailText = str.ReadToEnd();
            str.Close();
            mailText = mailText.Replace("[usename]",dto.UserName).Replace("[email]",dto.Email);
            await _mailService.SendEmailAsync(dto.Email, "Welcome to our Channel" , mailText);
            return Ok();
        }*/
    }
}
