using Account.API.Models;

namespace Account.API.Infrastructure.Services
{
    public interface IKeycloakAdminService
    {
        Task<List<UserRepresentation>> GetUsers(int first, int max, string search);
        Task<int> CountUsers(string search);
        Task<UserRepresentation> GetUser(string id);
        Task<UserRepresentation> GetUserByUsername(string username);
        Task<bool> UpdateUser(string id, UserRepresentation body);
        Task<bool> CreateUser(UserRepresentation body);
        Task<bool> ResetPassword(string id, CredentialRepresentation body);
    }
}
