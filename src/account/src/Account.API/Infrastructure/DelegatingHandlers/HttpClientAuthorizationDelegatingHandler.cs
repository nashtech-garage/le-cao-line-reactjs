using Account.API.Infrastructure.Services;
using Microsoft.Extensions.Options;

namespace Account.API.Infrastructure.DelegatingHandlers
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IKeycloakService _keycloakService;
        private readonly KeycloakSetting _setting;

        public HttpClientAuthorizationDelegatingHandler(
            IKeycloakService keycloakService,
            IOptions<KeycloakSetting> options)
        {
            _keycloakService = keycloakService;
            _setting = options.Value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _keycloakService.AdminLogin(_setting.Username, _setting.Password);

            if (token != null)
            {
                //request.Headers.Authorization = new AuthenticationHeaderValue("Basic", token);
                request.Headers.Add("Authorization", "Bearer " + token.access_token);
            }

            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
