using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<bool> DeleteUser(int id);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByUsername(string username);
        Task<bool> UpdatePassword(int id, string newPassword);
    }
}
