using MyEcommerce.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyEcommerce.Application.Interfaces
{
public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task CreateUserAsync(UserDto userDto);
    Task UpdateUserAsync(UserDto userDto);
    Task DeleteUserAsync(int id);
}

}