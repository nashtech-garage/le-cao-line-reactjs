namespace Account.API
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
    public class KeycloakSetting
    {
        public string Url { get; set; }
        public string ClientSecret { get; set; }
        public string GetToken { get; set; }
        public string Login { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Realm { get; set; }
        public string Admin { get; set; }
        public string Authority { get; set; }
        public string ClientId { get; set; }

        public string PostTokenUrl => Url + string.Format(GetToken, Realm);
        public string LoginUrl => Url + Login;
        public string AdminUrl => Url + string.Format(Admin, Realm);
        public string AuthorityUrl => Url + string.Format(Authority, Realm);
    }
    public class ServiceConfig
    {
        public Uri ServiceDiscoveryAddress { get; set; }
        public Uri ServiceAddress { get; set; }
        public string ServiceName { get; set; }
        public string ServiceId { get; set; }
    }
}