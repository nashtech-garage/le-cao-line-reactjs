using Catalog.API.Models;
using Newtonsoft.Json;
using System.Security.Claims;
using static Catalog.API.Models.IdentityUserModel;

namespace Catalog.API.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IdentityUserModel GetIdentityUser()
        {
            return GetIdentityUser(_context.HttpContext.User.Claims);
        }

        public string GetUserId()
        {
            var sub = _context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "sub");
            if (sub is not null)
            {
                return sub.Value;
            }

            return string.Empty;
        }

        public string GetUserRole()
        {
            return _context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
        }

        private IdentityUserModel GetIdentityUser(IEnumerable<Claim> claims)
        {
            if (claims is null || claims.Count() == 0)
                return null;

            var userClaims = claims.Select(x => new { x.Type, x.Value });

            IdentityUserModel result = new IdentityUserModel();

            foreach (var claim in userClaims)
            {
                switch (claim.Type)
                {
                    case "exp":
                        result.Exp = Convert.ToInt32(claim.Value);
                        break;
                    case "iat":
                        result.Iat = Convert.ToInt32(claim.Value);
                        break;
                    case "auth_time":
                        result.AuthTime = Convert.ToInt32(claim.Value);
                        break;
                    case "jti":
                        result.Jti = claim.Value;
                        break;
                    case "iss":
                        result.Iss = claim.Value;
                        break;
                    case "aud":
                        result.Aud = claim.Value;
                        break;
                    case "sub":
                        result.UserId = claim.Value;
                        break;
                    case "typ":
                        result.Typ = claim.Value;
                        break;
                    case "azp":
                        result.Azp = claim.Value;
                        break;
                    case "session_state":
                        result.SessionState = claim.Value;
                        break;
                    case "http://schemas.microsoft.com/claims/authnclassreference":
                        result.Acr = claim.Value;
                        break;
                    case "allowed-origins":
                        result.AllowedOrigins = claim.Value;
                        break;
                    case "realm_access":
                        result.RealmAccess = JsonConvert.DeserializeObject<RoleAccess>(claim.Value);
                        break;
                    case "resource_access":
                        result.ResourceAccess = JsonConvert.DeserializeObject<ResourceAccessData>(claim.Value);
                        break;
                    case "scope":
                        result.Scope = claim.Value;
                        break;
                    case "email_verified":
                        result.EmailVerified = Convert.ToBoolean(claim.Value);
                        break;
                    case "name":
                    case ClaimTypes.Name:
                        result.Name = claim.Value;
                        break;
                    case "preferred_username":
                        result.Username = claim.Value;
                        break;
                    case "given_name":
                    case ClaimTypes.GivenName:
                        result.GivenName = claim.Value;
                        break;
                    case "family_name":

                        result.FamilyName = claim.Value;
                        break;
                    case "email":

                    case ClaimTypes.Email:
                        result.Email = claim.Value;
                        break;
                    case "role":
                    case ClaimTypes.Role:
                        result.Roles.Add(claim.Value);
                        break;
                }
            }

            return result;
        }
    }
}