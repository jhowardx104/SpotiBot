namespace SpotiBot.Common.Authentication;

public interface IAuthenticationService{
    public Task<string?> RetrieveToken();
}