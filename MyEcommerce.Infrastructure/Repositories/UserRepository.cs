using MyEcommerce.Domain.Entities;
using MyEcommerce.Domain.Interfaces;
using MyEcommerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEcommerce.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyEcommerceDbContext _context; // ✅ FIXED: Using the correct variable name

        public UserRepository(MyEcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id) // ✅ Return nullable User
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id) // ✅ Fixed _dbContext reference
        {
            var user = await _context.Users.FindAsync(id); // ✅ FIXED: Changed `_dbContext` to `_context`
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
