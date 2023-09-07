namespace Notification.API.Infrastructure.ResponseGeneric
{
    public class TokenResponse
    {
        public string AccessToken { get; set; }
        public long Expires { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}
