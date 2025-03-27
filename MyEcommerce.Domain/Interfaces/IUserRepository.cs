using MyEcommerce.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEcommerce.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetByIdAsync(int id); // ✅ Nullable User
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task<bool> DeleteAsync(int id); // ✅ Ensure return type matches
    }
}
