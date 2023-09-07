using Account.API.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static Dapper.SqlMapper;

namespace Account.API.Infrastructure.Services
{
    public class KeycloakService : IKeycloakService
    {
        private readonly HttpClient _apiClient;
        private readonly KeycloakSetting _setting;
        private readonly ILogger<KeycloakService> _logger;
        public KeycloakService(
            HttpClient httpClient,
            IOptions<KeycloakSetting> options,
            ILogger<KeycloakService> logger
            )
        {
            _logger = logger;
            _apiClient = httpClient;
            _setting = options.Value;
        }

        public async Task<KeycloakToken> AdminLogin(string username, string password)
        {
            var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("client_id", "admin-cli"),
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });


            var response = await _apiClient.PostAsync(_setting.LoginUrl, formContent);

            var responseString = await response.Content.ReadAsStringAsync();

            var responseJson = JsonConvert.DeserializeObject<KeycloakToken>(responseString);

            return responseJson;
        }

        public async Task<KeycloakToken> UserLogin(string username, string password)
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("client_id", _setting.ClientId),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("client_secret",_setting.ClientSecret)
            });

            var response = await _apiClient.PostAsync(_setting.PostTokenUrl, formContent);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<KeycloakToken>(responseString);
            }
            else
            {
                _logger.LogError(responseString);
                return null;
            }
        }
    }
}
