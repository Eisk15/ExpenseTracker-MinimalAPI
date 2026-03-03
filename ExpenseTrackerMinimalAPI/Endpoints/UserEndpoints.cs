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
                return user != null ? Results.Ok(user) : Results.NotFound();
            });

            // Search by name
            app.MapGet("/users", async (IUserService userService, string userName) =>
            {
                var user = await userService.GetUserByUsernameAsync(userName);
                return user != null ? Results.Ok(user) : Results.NotFound();
            });

            // Create User
            app.MapPost("/users", async(IUserService userService, User user) =>
            {
                var createdUser = await userService.CreateUserAsync(user);
                return Results.Created($"/users/{createdUser.Id}", createdUser);
            });

            // Change password
            app.MapPatch("/users/{id}", async (IUserService userService, int id, string newPassword) => 
            {
                var isUpdated = await userService.UpdatePasswordAsync(id, newPassword);
                if (!isUpdated) { return Results.NotFound(); }
                return Results.NoContent(); 
            });

            // Delete User
            app.MapDelete("/users/{id}", async (IUserService userService, int id) => 
            {
                var isDeleted = await userService.DeleteUserAsync(id);
                if (!isDeleted) { return Results.NotFound(); }
                return Results.NoContent();
            });
        }
    }
}
