using Newtonsoft.Json;

namespace Account.API.Models
{
    public class UserRepresentation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdTimestamp")]
        public long CreatedTimestamp { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("totp")]
        public bool Totp { get; set; }

        [JsonProperty("emailVerified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("disableableCredentialTypes")]
        public List<string> DisableableCredentialTypes { get; set; }

        [JsonProperty("requiredActions")]
        public List<string> RequiredActions { get; set; }

        [JsonProperty("federatedIdentities")]
        public List<KeyCloakIdentityProvider> FederatedIdentities { get; set; }

        [JsonProperty("notBefore")]
        public int NotBefore { get; set; }

        [JsonProperty("access")]
        public KeyCloakAccess Access { get; set; }
    }
    public class KeyCloakAccess
    {
        [JsonProperty("manageGroupMembership")]
        public bool ManageGroupMembership { get; set; }
        [JsonProperty("view")]
        public bool View { get; set; }
        [JsonProperty("mapRoles")]
        public bool MapRoles { get; set; }
        [JsonProperty("impersonate")]
        public bool Impersonate { get; set; }
        [JsonProperty("manage")]
        public bool Manage { get; set; }
    }

    public class KeyCloakIdentityProvider
    {
        [JsonProperty("identityProvider")]
        public string IdentityProvider { get; set; }
        [JsonProperty("userId")]
        public string UserId { get; set; }
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }

    public class CredentialRepresentation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("createdDate")]
        public long CreatedDate { get; set; }

        [JsonProperty("credentialData")]
        public string CredentialData { get; set; }

        [JsonProperty("priority")]
        public int Priority { get; set; }

        [JsonProperty("secretData")]
        public string SecretData { get; set; }

        [JsonProperty("temporary")]
        public bool Temporary { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("userLabel")]
        public string UserLabel { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
