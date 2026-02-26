using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task<bool> UpdatePasswordAsync(int id, string newPassword);
    }
}
