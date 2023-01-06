using SpotiBot.Common.Authentication;

namespace SpotiBot.Common.Handlers;

public class OAuthDelegatingHandler: DelegatingHandler
{
    private readonly IAuthenticationService _authenticationService;

    public OAuthDelegatingHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
    }

    protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _authenticationService.RetrieveToken();
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        return await base.SendAsync(request, cancellationToken);
    }
}