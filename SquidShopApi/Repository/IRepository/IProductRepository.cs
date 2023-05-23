using SquidShopApi.Models;

namespace SquidShopApi.Repository.IRepository
{
	public interface IProductRepository
	{
		Task<List<Product>> GetAllIncluded();
	}
}
