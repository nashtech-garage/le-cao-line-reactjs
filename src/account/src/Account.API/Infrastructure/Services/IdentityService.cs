using Account.API.Models;
using Account.Domain.AggregatesModel;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using static Account.API.Models.IdentityUserModel;
using Microsoft.Extensions.Primitives;

namespace Account.API.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly Audience _audience;
        private readonly IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context, IOptions<Audience> options)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _audience = options.Value;
        }

        public string GenerateToken(User user, List<string> roles, int timeOut)
        {
            var now = DateTime.UtcNow;
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, JsonConvert.SerializeObject(roles), JsonClaimValueTypes.JsonArray)
            };

            var signingkey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_audience.Secret));
            var jwt = new JwtSecurityToken(
                issuer: _audience.Iss,
                audience: _audience.Name,
                claims: claims,
                notBefore: now,
                expires: now.Add(TimeSpan.FromSeconds(timeOut)),
                signingCredentials: new SigningCredentials(signingkey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public IdentityUserModel GetIdentityUser()
        {
            return GetIdentityUser(_context.HttpContext.User.Claims);
        }

        public IdentityUserModel GetIdentityUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            return GetIdentityUser(jwtToken.Claims);
        }

        public string GetMD5(string password)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                md5.ComputeHash(Encoding.ASCII.GetBytes(password));
                byte[] result = md5.Hash;
                StringBuilder str = new StringBuilder();

                for (int i = 0; i < result.Length; i++)
                {
                    str.Append(result[i].ToString("x2"));
                }

                return str.ToString();
            }
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

        public string GetUserIp()
        {
            StringValues userIpValue;
            bool xIpHeader = _context.HttpContext.Request.Headers.TryGetValue("X-Real-IP", out userIpValue);
            if (xIpHeader)
            {
                return userIpValue.ToString();
            }
            return _context.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public string GetUserRole()
        {
            return _context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
        }

        public bool VerifyMd5Hash(string hashPassword, string passwordMD5)
        {
            StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;

            if (0 == stringComparer.Compare(hashPassword, passwordMD5))
            {
                return true;
            }
            else
            {
                return false;
            }
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
