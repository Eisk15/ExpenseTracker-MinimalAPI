using ExpenseTrackerMinimalAPI.Interfaces;
using ExpenseTrackerMinimalAPI.Data;
using ExpenseTrackerMinimalAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace ExpenseTrackerMinimalAPI.Services
{
    public class ExpenseService : IExpenseService
    {
        // Field
        private readonly AppDbContext _context;

        // Constructor
        public ExpenseService (AppDbContext context)
        {
            _context = context;
        }

        // Methods

        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }

        public async Task<List<Expense>> GetExpensesAsync()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<List<Expense>> GetExpensesByUserAsync(int id)
        {
            return await _context.Expenses
                .Where(e => e.UserId == id)
                .ToListAsync();
        }

        public async Task<Expense> CreateExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            // Find expense
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null) { return false; }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
