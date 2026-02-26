using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Interfaces
{
    public interface IExpenseService
    {
        Task<Expense?> GetExpenseByIdAsync(int id);
        Task<List<Expense>> GetExpensesAsync();
        Task<List<Expense>> GetExpensesByUserAsync(int userId);
        Task<Expense> CreateExpenseAsync(Expense expense);
        Task<bool> DeleteExpenseAsync(int id);
    }
}
