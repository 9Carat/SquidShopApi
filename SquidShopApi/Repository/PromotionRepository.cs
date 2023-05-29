using Microsoft.EntityFrameworkCore;
using SquidShopApi.Data;
using SquidShopApi.Models;
using SquidShopApi.Repository.IRepository;
using System.Linq.Expressions;

namespace SquidShopApi.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ApplicationDbContext _context;
        public PromotionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Promotion entity)
        {
            await _context.Promotion.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<Promotion>> GetAllAsync()
        {
            var result = _context.Promotion;
            return await result.ToListAsync();
        }

        public async Task<Promotion> GetByIdAsync(Expression<Func<Promotion, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Promotion> query = _context.Promotion;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Promotion entity)
        {
            _context.Promotion.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Promotion entity)
        {
            _context.Promotion.Update(entity);
            await SaveAsync();
           
        }
    }
}
