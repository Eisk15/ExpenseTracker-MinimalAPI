using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Interfaces
{
    public interface IExpenseService
    {
        Expense GetExpenseById(int id);
        List<Expense> GetExpenses();
        List<Expense> GetExpenseByUser(int userId);
        Expense CreateExpense(Expense expense);
        Expense UpdateExpense(Expense expense);
        bool DeleteExpense(int id);
    }
}
