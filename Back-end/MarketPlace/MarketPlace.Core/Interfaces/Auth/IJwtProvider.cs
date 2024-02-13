namespace MarketPlace.Core.Interfaces.Auth
{
    public interface IJwtProvider
    {
        string GenerateAuthToken(string userId, string userRole);
    }
}