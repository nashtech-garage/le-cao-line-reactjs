namespace Account.API.Models
{
    public class IdentityUserModel
    {
        public int Exp { get; set; }
        public int Iat { get; set; }

        public int AuthTime { get; set; }

        public string Jti { get; set; }
        public string Iss { get; set; }
        public string Aud { get; set; }
        public string UserId { get; set; }
        public string Typ { get; set; }
        public string Azp { get; set; }

        public string SessionState { get; set; }

        public string Acr { get; set; }

        public string AllowedOrigins { get; set; }

        public RoleAccess RealmAccess { get; set; }

        public ResourceAccessData ResourceAccess { get; set; }

        public string Scope { get; set; }

        public bool EmailVerified { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();


        public class RoleAccess
        {
            public List<string> Roles { get; set; }
        }

        public class ResourceAccessData
        {
            public RoleAccess Account { get; set; }
        }

        public void AddRole(string role)
        {
            Roles.Add(role);
        }
    }
}
