namespace Notification.API
{
    public class AccountSettings
    {        
    }

    public class KafkaSettings
    {
        public string PublishTopic { get; set; }
        public string SubscribeTopic { get; set; }
        public string BootstrapServers { get; set; }
        public string GroupId { get; set; }
    }
    public class ServiceConfig
    {
        public Uri ServiceDiscoveryAddress { get; set; }
        public Uri ServiceAddress { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
    }
    public class EmailSettings
    {
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
    }
}