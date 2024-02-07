using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Core.Models
{
    internal class UserModel
    {
        public UserModel(Guid id, string un, string email, bool emailConf, string passHash, string role)
        {
            Id = id;
            Username = un;
            Email = email;
            EmailConfirm = emailConf;
            PasswordHash = passHash;
            Role = role;
        }
        public Guid Id { get; }
        public string Username { get; }
        public string Email { get; }
        public bool EmailConfirm { get; }
        public string PasswordHash { get; }
        public string Role { get; }
        public string ErrorMessege { get; }
        public static UserModel CreateUser(Guid id, string un, string email, bool emailConf, string passHash, string role) 
            => new UserModel(id, un, email, emailConf, passHash, role);
    }
}
