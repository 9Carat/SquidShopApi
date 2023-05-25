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

        public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        {
            IQueryable<User> temp = _context.Users;
            if (filter != null)
            {
                temp = temp.Where(filter);
            }
            return await temp.Include(x => x.Orders).ToListAsync();
        }

        public async Task<User> GetByIdAsync(Expression<Func<User, bool>>? filter = null, bool tracked = true)
        {
            IQueryable<User> temp = _context.Users.Include(x => x.Orders);
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
