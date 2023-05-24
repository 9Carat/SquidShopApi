using SquidShopApi.Models;
using System.Linq.Expressions;

namespace SquidShopApi.Repository.IRepository
{
    public interface IOrderListRepository 
    {
        Task<List<OrderList>> GetAllAsync(Expression<Func<OrderList, bool>>? filter = null);
        Task<OrderList> GetByIdAsync(Expression<Func<OrderList, bool>>? filter = null, bool tracked = true);
        Task CreateAsync(OrderList entity);
        Task RemoveAsync(OrderList entity);
        Task<OrderList> UpdateAsync(OrderList entity);
        Task<OrderList> UpdatePartialAsync(OrderList entity);
        Task SaveAsync();
    }
}
