using ExpenseTrackerMinimalAPI.Interfaces;
using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Endpoints
{
    public static class ExpenseEndpoints
    {
        public static void MapExpenseEndpoints(this WebApplication app)
        {
            app.MapGet("/expense/{userId}", async(IExpenseService eservice, int userId) =>
            {
                var expenses = await eservice.GetExpensesByUserAsync(userId);
                return Results.Ok(expenses);
            });


            
        }
    }
}
