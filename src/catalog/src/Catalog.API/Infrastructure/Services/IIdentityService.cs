using Catalog.API.Models;

namespace Catalog.API.Infrastructure.Services
{
    public interface IIdentityService
    {
        IdentityUserModel GetIdentityUser();
        string GetUserId();
        string GetUserRole();
    }
}