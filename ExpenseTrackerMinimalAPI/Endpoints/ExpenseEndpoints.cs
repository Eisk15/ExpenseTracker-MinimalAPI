using ExpenseTrackerMinimalAPI.Interfaces;
using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Endpoints
{
    public static class ExpenseEndpoints
    {
        public static void MapExpenseEndpoints(this WebApplication app)
        {
            // Get expenses by user id
            app.MapGet("/users/{userId}/expenses", async (IExpenseService expenseService, int userId) =>
            {
                var expenses = await expenseService.GetExpensesByUserAsync(userId);
                return Results.Ok(expenses);
            });

            // Get expense by expense id
            app.MapGet("/expenses/{id}", async (IExpenseService expenseService, int id) =>
            {
                var expense = await expenseService.GetExpenseByIdAsync(id);
                return expense != null ? Results.Ok(expense) : Results.NotFound();
            });


            // Get all expenses
            app.MapGet("/expenses", async(IExpenseService expenseService) =>
            {
                var expenses = await expenseService.GetExpensesAsync();
                return Results.Ok(expenses);
            });

            // Create expense
            app.MapPost("/expenses", async(IExpenseService expenseService, Expense expense) =>
            {
                var createdExpense = await expenseService.CreateExpenseAsync(expense);
                return Results.Created($"/expenses/{createdExpense.Id}", createdExpense);
            });


            app.MapDelete("/expenses/{id}", async(IExpenseService expenseService, int id) =>
            {
                var isDeleted = await expenseService.DeleteExpenseAsync(id);
                return !isDeleted ? Results.NotFound() : Results.NoContent();
            });


            
        }
    }
}
