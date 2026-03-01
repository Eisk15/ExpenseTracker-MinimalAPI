using ExpenseTrackerMinimalAPI.Interfaces;
using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            
            // Search by id
            app.MapGet("/users/{id}", async (IUserService userService, int id) =>
            {
                var user = await userService.GetUserByIdAsync(id);
                return Results.Ok(user);
            });

            // Search by name
            app.MapGet("/users", async (IUserService userService, string userName) =>
            {
                if (userName != null)
                {
                    var user = await userService.GetUserByUsernameAsync(userName);
                    return Results.Ok(user);
                }
                return Results.NotFound();
            });

            // Create User
            app.MapPost("/users/", async(IUserService userSerivce, User user) =>
            {
                var createdUser = await userSerivce.CreateUserAsync(user);
                return Results.Created();
            });

            // Change password
            app.MapPatch("/users/{id}", async (IUserService userService, int id, string pass) => 
            {
                var user = await userService.UpdatePasswordAsync(id, pass);
                return Results.Ok(user);
            });

            // Delete User
            app.MapDelete("/users/{id}", async (IUserService userService, int id) => 
            {
                var user = await userService.DeleteUserAsync(id);
                return Results.Ok(user);
            });
        }
    }
}
