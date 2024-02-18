
using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Auth
{
    public interface IUsersService
    {
        Task<(string, string)> Login(string email, string password);
        Task<(Guid, string)> Registration(string email, string username, string password);
        Task<UserModel> GetUserById(Guid id);
    }
}