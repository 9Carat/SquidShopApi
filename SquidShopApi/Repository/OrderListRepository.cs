using SquidShopApi.Data;
using SquidShopApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using SquidShopApi.Repository.IRepository;

namespace SquidShopApi.Repository
{
    public class OrderListRepository : IOrderListRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderListRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(OrderList entity)
        {    
            await _context.OrderLists.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<OrderList>> GetAllAsync(Expression<Func<OrderList, bool>> filter = null)
        {
            IQueryable<OrderList> temp = _context.OrderLists.Include(x => x.Orders).Include(x => x.Products);
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.OrderBy(x=>x.OrderListId).ToListAsync();
        }

        public async Task<OrderList> GetByIdAsync(Expression<Func<OrderList, bool>> filter = null, bool tracked = true)
        {
            IQueryable<OrderList> temp = _context.OrderLists.Include(x => x.Orders).Include(x => x.Products);
            if (!tracked == true)
            {
                temp = temp.AsNoTracking();
            }
            if (filter != null)
            {
                temp = temp.Where(filter);
                    
            }
            return await temp.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(OrderList entity)
        {
            _context.OrderLists.Remove(entity);
            await SaveAsync();
        }
        

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<OrderList> UpdateAsync(OrderList entity)
        {
            _context.OrderLists.Update(entity);
            await SaveAsync();
            return entity;
        }
        public async Task<OrderList> UpdatePartialAsync(OrderList entity)
        {
            _context.OrderLists.Update(entity);
            await SaveAsync();
            return entity;
        }
    }
}
