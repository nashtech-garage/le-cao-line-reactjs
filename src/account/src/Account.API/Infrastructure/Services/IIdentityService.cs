using Account.API.Models;
using Account.Domain.AggregatesModel;

namespace Account.API.Infrastructure.Services
{
    public interface IIdentityService
    {
        IdentityUserModel GetIdentityUser();
        IdentityUserModel GetIdentityUser(string token);
        string GetUserId();
        string GetUserIp();
        string GetUserRole();
        string GetMD5(string password);
        bool VerifyMd5Hash(string hashPassword, string passwordMD5);
        string GenerateToken(User user, List<string> roles, int timeOut);

    }
}
