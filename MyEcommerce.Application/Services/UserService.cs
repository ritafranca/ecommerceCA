using MyEcommerce.Application.DTOs;
using MyEcommerce.Application.Interfaces;
using MyEcommerce.Domain.Entities;
using MyEcommerce.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEcommerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username ?? string.Empty,
                Email = u.Email ?? string.Empty
            }).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user == null ? null : new UserDto
            {
                Id = user.Id,
                Username = user.Username ?? string.Empty,
                Email = user.Email ?? string.Empty
            };
        }

        public async Task CreateUserAsync(UserDto userDto) // ✅ FIXED: Return type should be Task
        {
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = userDto.PasswordHash
            };

            await _userRepository.AddAsync(user);
        }

        public async Task UpdateUserAsync(UserDto userDto) // ✅ FIXED: Return type should be Task
        {
            var user = await _userRepository.GetByIdAsync(userDto.Id);
            if (user == null) throw new Exception($"User with ID {userDto.Id} not found.");

            user.Username = userDto.Username;
            user.Email = userDto.Email;

            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteAsync(id); // ✅ FIXED: Removed assignment to bool
        }


    }
}
