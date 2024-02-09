using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<Guid> AddUserAsync(UserModel model);
        Task<Guid> DeleteUserAsync(Guid id);
        Task<UserModel?> GetUserByIdAsync(Guid id);
        Task<Guid> UpdateUserAsync(UserModel model);
    }
}