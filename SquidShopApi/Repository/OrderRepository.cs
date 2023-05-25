using SquidShopApi.Data;
using SquidShopApi.Models;
using SquidShopApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace SquidShopApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Order entity)
        {    
            await _context.Orders.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<Order>> GetAllAsync(Expression<Func<Order, bool>> filter = null)
        {
            IQueryable<Order> temp = _context.Orders.Include(x => x.Users);
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.Select(o => new Order
            {
                OrderId = o.OrderId,
                FK_UserId = o.FK_UserId,
                Users = o.Users,
                CreatedAt = o.CreatedAt,
                OrderLists = o.OrderLists,
                OrderStatus = o.OrderStatus,

            }).ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Expression<Func<Order, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<Order> temp = _context.Orders.Include(x => x.Users);
            if (!tracked == true)
            {
                temp = temp.AsNoTracking();
            }
            if (filter != null)
            {
                temp = temp.Where(filter);
                    
            }
            return await temp.Select(o=> new Order
            {
                OrderId = o.OrderId,
                FK_UserId = o.FK_UserId,
                Users = o.Users,
                CreatedAt = o.CreatedAt,
                OrderLists = o.OrderLists,
                OrderStatus = o.OrderStatus,
                
            }).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Order entity)
        {
            _context.Orders.Remove(entity);
            await SaveAsync();
        }
        

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            _context.Orders.Update(entity);
            await SaveAsync();
            return entity;
        }
    }
}
