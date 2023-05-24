using SquidShopApi.Models;
using System.Linq.Expressions;

namespace SquidShopApi.Repository.IRepository
{
    public interface IOrderRepository 
    {
        Task<List<Order>> GetAllAsync(Expression<Func<Order, bool>>? filter = null);
        Task<Order> GetByIdAsync(Expression<Func<Order, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(Order entity);
        Task RemoveAsync(Order entity);
        Task<Order> UpdateAsync(Order entity);
        Task SaveAsync();
    }
}
