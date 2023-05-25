using SquidShopApi.Models;
using System.Linq.Expressions;

namespace SquidShopApi.Repository.IRepository
{
    public interface ICategoryRepository 
    {
        Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>>? filter = null);
        Task<Category> GetByIdAsync(Expression<Func<Category, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(Category entity);
        Task RemoveAsync(Category entity);
        Task<Category> UpdateAsync(Category entity);
        Task SaveAsync();
    }
}
