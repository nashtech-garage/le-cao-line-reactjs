namespace Notification.API.Infrastructure.Services
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
    }
}
