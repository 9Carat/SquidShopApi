using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;
using SquidShopApi.Data;
using SquidShopApi.Models;
using SquidShopApi.Repository.IRepository;
using System.Linq.Expressions;

namespace SquidShopApi.Repository
{
	public class ProductRepository : IProductRepository
	{
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

		public async Task CreateAsync(Product entity)
		{
			await _db.Products.AddAsync(entity);
			await SaveAsync();
		}

		public async Task<List<Product>> GetAllAsync()
        {
            var result = _db.Products
                 .Include(c => c.Categories);
            return await result.ToListAsync();
        }

		public async Task<Product> GetByIdAsync(Expression<Func<Product, bool>> filter = null, bool tracked = true)
		{
			IQueryable<Product> query = _db.Products;
			if (!tracked == true)
			{
				query = query.AsNoTracking();
			}
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query
				.Include(c => c.Categories)
				.FirstOrDefaultAsync();
		}

		public async Task RemoveAsync(Product entity)
		{
			_db.Remove(entity);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await _db.SaveChangesAsync();
		}

		public async Task UpdateAsync(Product entity)
		{
			_db.Update(entity);
			await SaveAsync();
		}
	}
}
