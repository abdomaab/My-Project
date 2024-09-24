namespace SendEmail.Service
{
    public interface IMailService
    {
        Task SendEmailAsync(string email, string subject, string body, IList<IFormFile> Attachments = null);
    }
}
