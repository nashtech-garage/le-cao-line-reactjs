using Account.API.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Account.API.Infrastructure.Services
{
    public class KeycloakAdminService : IKeycloakAdminService
    {
        #region Helper
        private StringContent GetContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
        private T ConvertTo<T>(string responseString)
        {
            if (string.IsNullOrEmpty(responseString))
                return default(T);

            try
            {
                var result = JsonConvert.DeserializeObject<T>(responseString);
                return result;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        private async Task<T> GetAsync<T>(string uri)
        {
            var response = await _apiClient.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(responseString))
            {
                var item = ConvertTo<T>(responseString);
                return item;
            }
            return default(T);
        }

        private async Task<bool> PostAsync(string uri, object body)
        {
            var response = await _apiClient.PostAsync(uri, GetContent(body));
            var responseString = await response.Content.ReadAsStringAsync();
            return response.IsSuccessStatusCode;
        }


        private async Task<bool> PutAsync(string uri, object body)
        {
            var bodyContent = GetContent(body);

            var response = await _apiClient.PutAsync(uri, bodyContent);

            return response.IsSuccessStatusCode;
        }


        #endregion
        private readonly HttpClient _apiClient;
        private readonly KeycloakSetting _setting;
        public KeycloakAdminService(
            HttpClient httpClient,
            IOptions<KeycloakSetting> options
            )
        {
            _apiClient = httpClient;
            _setting = options.Value;
        }

        public async Task<UserRepresentation> GetUser(string id)
        {
            var url = KeyCloakApi.Users.UserById(_setting.AdminUrl, id);

            var responseJson = await GetAsync<UserRepresentation>(url);

            return responseJson;
        }

        public async Task<bool> UpdateUser(string id, UserRepresentation body)
        {
            var url = KeyCloakApi.Users.UserById(_setting.AdminUrl, id);

            return await PutAsync(url, body);
        }

        public async Task<bool> CreateUser(UserRepresentation body)
        {
            var url = KeyCloakApi.Users.Create(_setting.AdminUrl);

            return await PostAsync(url, body);
        }


        public async Task<List<UserRepresentation>> GetUsers(int first, int max, string search)
        {
            var url = KeyCloakApi.Users.GetUsers(_setting.AdminUrl, first, max, search);

            return await GetAsync<List<UserRepresentation>>(url);
        }

        public async Task<int> CountUsers(string search)
        {
            var url = KeyCloakApi.Users.Count(_setting.AdminUrl, search);

            return await GetAsync<int>(url);
        }
        public async Task<bool> ResetPassword(string id, CredentialRepresentation body)
        {

            var url = KeyCloakApi.Users.ResetPassword(_setting.AdminUrl, id);

            return await PutAsync(url, body);
        }

        public async Task<UserRepresentation> GetUserByUsername(string username)
        {
            var url = KeyCloakApi.Users.UserByUsername(_setting.AdminUrl, username);

            var responseJson = await GetAsync<List<UserRepresentation>>(url);

            return responseJson?.FirstOrDefault();
        }
    }
}
