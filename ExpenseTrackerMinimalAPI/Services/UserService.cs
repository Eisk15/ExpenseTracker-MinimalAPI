using ExpenseTrackerMinimalAPI.Models;
using ExpenseTrackerMinimalAPI.Interfaces;
using ExpenseTrackerMinimalAPI.Data;
using Microsoft.EntityFrameworkCore;
namespace ExpenseTrackerMinimalAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        // Constructor
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Methods

        public async Task<User> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            // Find user
            var user = await _context.Users.FindAsync(id);
            if (user==null) { return false; }

            // Delete user
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> UpdatePasswordAsync(int id, string newPassword)
        {
            // Find user
            var user = await _context.Users.FindAsync(id);
            if(user == null) { return false; }

            // Change pass
            user.PasswordHash = newPassword;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
