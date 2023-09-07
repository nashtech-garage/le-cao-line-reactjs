using Account.API.Models;

namespace Account.API.Infrastructure.Services
{
    public interface IKeycloakService
    {
        Task<KeycloakToken> AdminLogin(string username, string password);
        Task<KeycloakToken> UserLogin(string username, string password);
    }
}
