using MarketPlace.Core.Interfaces.Auth;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Application.Services
{
    public class UsersService : IUsersService
    {
        private IUserRepository _userRepository;
        private ISellerRepository _sellerRepository;
        private IJwtProvider _jwtProvider;
        private IPasswordHasher _passwordHasher;
        public UsersService(IUserRepository userRepository, IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<(Guid, string)> Registration(string email, string username, string password)
        {
            if (await _userRepository.GetUserByEmailAsync(email) != null)
                return (new Guid(), "User with this email already exists");

            var hash = _passwordHasher.GenerateHash(password);
            var user = UserModel.CreateUser(Guid.NewGuid(), username, email, false, hash, string.Empty, null);

            if (!user.Item2.IsNullOrEmpty())
                return (new Guid(), user.Item2);

            await _userRepository.AddUserAsync(user.Item1);

            return (user.Item1.Id, string.Empty);
        }
        public async Task<(string, string)> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null || !_passwordHasher.Verify(password, user.PasswordHash))
                return (string.Empty, "Incorrect email or password");

            var token = _jwtProvider.GenerateAuthToken(user.Id.ToString(), user.Role, user.SellerId);

            return (token, string.Empty);
        }
        public async Task<UserModel> GetUserById(Guid id)
        {
            var model = await _userRepository.GetUserByIdAsync(id);

            if (model == null)
                throw new ArgumentNullException(nameof(model), $"User with id:{id} is null");

            return model;
        }
        public async Task<(Guid, string)> RegistrationSeller(Guid userId, string phoneNumber)
        {
            var userModel = await GetUserById(userId);
            var model = SellerModel.CreateSeller(Guid.NewGuid(), phoneNumber, userModel);

            if (!model.Item2.IsNullOrEmpty())
                return (model.Item1.Id, model.Item2);

            var result = await _sellerRepository.AddSellerAsync(model.Item1);

            return (result, string.Empty);
        }
    }
}