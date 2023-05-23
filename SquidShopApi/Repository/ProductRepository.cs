using Microsoft.EntityFrameworkCore;
using SquidShopApi.Data;
using SquidShopApi.Models;
using SquidShopApi.Repository.IRepository;

namespace SquidShopApi.Repository
{
	public class ProductRepository : IProductRepository
	{
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<Product>> GetAllIncluded()
        {
            var result = _db.Products
                 .Include(c => c.Categories);
            return await result.ToListAsync();
        }
    }
}
