using SquidShopApi.Models;
using System.Linq.Expressions;

namespace SquidShopApi.Repository.IRepository
{
    public interface IUserRepository 
    {
        //Task<List<User>> GetAllAsync(Expression<Func<User, bool>>? filter = null);
        //Task<User> GetByIdAsync(Expression<Func<User, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(User entity);
        Task RemoveAsync(User entity);
        Task<User> UpdateAsync(User entity);
        Task SaveAsync();
    }
}
