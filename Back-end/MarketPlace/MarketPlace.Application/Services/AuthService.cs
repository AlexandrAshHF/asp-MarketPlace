﻿using MarketPlace.Core.Interfaces.Auth;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Application.Services
{
    public class AuthService : IAuthService
    {
        private IUserRepository _userRepository;
        private IJwtProvider _jwtProvider;
        private IPasswordHasher _passwordHasher;
        public AuthService(IUserRepository userRepository, IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
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
            var user = UserModel.CreateUser(Guid.NewGuid(), username, email, false, hash, string.Empty);

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

            var token = _jwtProvider.GenerateAuthToken(user.Id.ToString(), user.Role);

            return (token, string.Empty);
        }
    }
}