
namespace MarketPlace.Core.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<(string, string)> Login(string email, string password);
        Task<(Guid, string)> Registration(string email, string username, string password);
    }
}