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
	public class CategoryRepository : ICategoryRepository
	{
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

		public async Task CreateAsync(Category entity)
		{
			await _context.Categories.AddAsync(entity);
			await SaveAsync();
		}

		public async Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>>? filter = null)
        {
			var result = _context.Categories;
            return await result.ToListAsync();
        }

		public async Task<Category> GetByIdAsync(Expression<Func<Category, bool>> filter = null, bool tracked = true)
		{
			IQueryable<Category> query = _context.Categories;
			if (!tracked == true)
			{
				query = query.AsNoTracking();
			}
			if (filter != null)
			{
				query = query.Where(filter);
			}
			return await query.FirstOrDefaultAsync();
		}

		public async Task RemoveAsync(Category entity)
		{
			_context.Remove(entity);
			await SaveAsync();
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

        public async Task<Category> UpdateAsync(Category entity)
        {
            _context.Categories.Update(entity);
            await SaveAsync();
            return entity;
        }
    }
}
