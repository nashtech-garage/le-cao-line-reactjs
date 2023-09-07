namespace Account.API.Models
{
    public class KeyCloakApi
    {
        public static class Users
        {
            public static string Create(string baseUrl) => baseUrl + "/users";
            public static string GetUsers(string baseUrl, int first, int max, string search) => baseUrl + $"/users?first={first}&max={max}&search={search}";
            public static string Count(string baseUrl, string search) => baseUrl + $"/users/count?search={search}";
            public static string Profile(string baseUrl) => baseUrl + "/users/profile";
            public static string UserById(string baseUrl, string id) => baseUrl + $"/users/{id}";
            public static string UserByUsername(string baseUrl, string username) => baseUrl + $"/users?username={username}";
            public static string ResetPassword(string baseUrl, string id) => baseUrl + $"/users/{id}/reset-password";

        }
    }
}
