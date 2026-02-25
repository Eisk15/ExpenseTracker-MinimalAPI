using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Interfaces
{
    public interface IUserService
    {
        User CreateUser(User user);
        bool DeleteUser(int id);
        User GetUserById(int id);
        User GetUserByUsername(string username);
        bool UpdatePassword(int id, string newPassword);
    }
}
