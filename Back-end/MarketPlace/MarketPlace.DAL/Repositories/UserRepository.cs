using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using MarketPlace.DAL.Enities;

namespace MarketPlace.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<UserModel?> GetUserByIdAsync(Guid id)
        {
            var entity = await _context.Users.FindAsync(id);

            if (entity == null)
                return null;

            var model = UserModel.CreateUser(entity.Id, entity.Username, entity.Email,
                                             entity.EmailConfirm, entity.PasswordHash, entity.Role).Item1;

            return model;
        }
        public async Task<Guid> AddUserAsync(UserModel model)
        {
            var entity = new UserEntity
            {
                Id = model.Id,
                Username = model.Username,
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                Role = model.Role,
                EmailConfirm = model.EmailConfirm,
                Seller = null,
            };

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }
        public async Task<Guid> UpdateUserAsync(UserModel model)
        {
            var entity = new UserEntity
            {
                Id = model.Id,
                Username = model.Username,
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                Role = model.Role,
                EmailConfirm = model.EmailConfirm,
            };

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity.Id;

        }
        public async Task<Guid> DeleteUserAsync(Guid id)
        {
            _context.Users.Remove(new UserEntity { Id = id });
            await _context.SaveChangesAsync();

            return id;
        }
    }
}