using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;

namespace MarketPlace.Application.Services
{
    public class UserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<(Guid, string)> Registration(string email, string username, string password)
        {
            return (new Guid(), string.Empty);
        }
    }
}
