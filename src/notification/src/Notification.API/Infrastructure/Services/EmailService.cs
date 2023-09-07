using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Net.Mail;

namespace Notification.API.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger _logger;
        private readonly EmailSettings _settings;
        public EmailService(IOptions<EmailSettings> options, ILogger<EmailService> logger)
        {
            _settings = options.Value ?? throw new ArgumentNullException(nameof(options));
            _logger = logger;
        }

        public async Task SendAsync(string to, string subject, string body)
        {
            using (var sender = new SmtpClient(_settings.SmtpServer, _settings.Port))
            {
                sender.UseDefaultCredentials = false;
                sender.Credentials = new System.Net.NetworkCredential(_settings.Email, _settings.AccessToken);
                sender.EnableSsl = _settings.EnableSsl;

                MailMessage message = new MailMessage(_settings.Email, to)
                {
                    Body = body,
                    Subject = subject,
                    IsBodyHtml = true
                };

                sender.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

                await sender.SendMailAsync(message);
            }
        }

        bool mailSent = false;
        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = e.UserState.ToString();

            if (e.Cancelled)
            {
                _logger.LogInformation("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                _logger.LogInformation("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                _logger.LogInformation("Message sent.");
            }
            mailSent = true;
        }

    }
}
