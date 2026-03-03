using ExpenseTrackerMinimalAPI.Interfaces;
using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Endpoints
{
    public static class ExpenseEndpoints
    {
        public static void MapExpenseEndpoints(this WebApplication app)
        {
            // Get expense by user id
            app.MapGet("/expense{userId}", async (IExpenseService eservice, int userId) =>
            {
                var expenses = await eservice.GetExpensesByUserAsync(userId);
                return Results.Ok(expenses);
            });

            // Get expense by expense id
            app.MapGet("/expense/{id}", async (IExpenseService eserivce, int id) =>
            {
                var expense = await eserivce.GetExpenseByIdAsync(id);
                return expense != null ? Results.Ok(expense) : Results.NotFound();
            });


            // Get all expenses
            app.MapGet("/expenses", async(IExpenseService eservice) =>
            {
                var expenses = await eservice.GetExpensesAsync();
                return Results.Ok(expenses);
            });

            // Create expense
            app.MapPost("/expenses/", async(IExpenseService eservice, Expense expense) =>
            {
                var createdExpense = await eservice.CreateExpenseAsync(expense);
                return Results.Created($"/expense/{createdExpense.Id}", createdExpense);
            });


            app.MapDelete("/expenses/{id}", async(IExpenseService eservice, int id) =>
            {
                var expense = await eservice.DeleteExpenseAsync(id);
                return !expense ? Results.NotFound() : Results.NoContent();
            });


            
        }
    }
}
