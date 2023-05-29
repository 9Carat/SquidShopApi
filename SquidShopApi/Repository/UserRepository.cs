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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User entity)
        {    
            await _context.Users.AddAsync(entity);
            await SaveAsync();
        }

        //public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        //{
        //    IQueryable<User> temp = _context.Users.Include(x => x.Orders);
        //    if (filter != null)
        //    {
        //        temp = temp.Where(filter);
        //    }
        //    return await temp.Select(u=> new User
        //    {
        //        UserId = u.UserId,
        //        FirstName = u.FirstName,
        //        LastName = u.LastName,
        //        Address = u.Address,
        //        PostalCode = u.PostalCode,
        //        City = u.City,
        //        FK_UsersId = u.FK_UsersId,
        //        Orders = u.Orders.Select(o=> new Order
        //        {
        //            OrderId = o.OrderId,
        //            OrderStatus = o.OrderStatus,
        //            CreatedAt = o.CreatedAt,
        //            FK_UserId = o.FK_UserId,
        //        }).ToList()
        //    }).ToListAsync();
        //}

        //public async Task<User> GetByIdAsync(Expression<Func<User, bool>>? filter = null, bool tracked = true)
        //{
        //    IQueryable<User> temp = _context.Users.Include(x => x.Orders);
        //    if (!tracked == true)
        //    {
        //        temp = temp.AsNoTracking();
        //    }
        //    if (filter != null)
        //    {
        //        temp = temp.Where(filter);
                    
        //    }
        //    return await temp.Select(u => new User
        //    {
        //        UserId = u.UserId,
        //        FirstName = u.FirstName,
        //        LastName = u.LastName,
        //        Address = u.Address,
        //        PostalCode = u.PostalCode,
        //        City = u.City,
        //        FK_UsersId = u.FK_UsersId,
        //        Orders = u.Orders.Select(o => new Order
        //        {
        //            OrderId = o.OrderId,
        //            OrderStatus = o.OrderStatus,
        //            CreatedAt = o.CreatedAt,
        //            FK_UserId = o.FK_UserId,
        //        }).ToList()
        //    }).FirstOrDefaultAsync();
        //}

        public async Task RemoveAsync(User entity)
        {
            _context.Users.Remove(entity);
            await SaveAsync();
        }
        

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await SaveAsync();
            return entity;
        }
    }
}
