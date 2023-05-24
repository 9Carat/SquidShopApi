using SquidShopApi.Models;
using System.Linq.Expressions;

namespace SquidShopApi.Repository.IRepository
{
	public interface IProductRepository
	{
		Task<List<Product>> GetAllAsync();
		Task<Product> GetByIdAsync(Expression<Func<Product, bool>> filter = null, bool tracked = true);
		Task CreateAsync(Product entity);
		Task RemoveAsync(Product entity);
		Task UpdateAsync(Product entity);
		Task SaveAsync();
	}
}
