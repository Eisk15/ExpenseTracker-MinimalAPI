using ExpenseTrackerMinimalAPI.Interfaces;
using ExpenseTrackerMinimalAPI.Models;
using System.Reflection.Metadata.Ecma335;
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
                return Results.Created($"/users/{createdUser.Id}", createdUser);
            });

            // Change password
            app.MapPatch("/users/{id}", async (IUserService userService, int id, string pass) => 
            {
                var user = await userService.UpdatePasswordAsync(id, pass);
                if (!user) { return Results.NotFound(); }
                return Results.NoContent();
            });

            // Delete User
            app.MapDelete("/users/{id}", async (IUserService userService, int id) => 
            {
                var user = await userService.DeleteUserAsync(id);
                if (!user) { return Results.NotFound(); }
                return Results.NoContent();
            });
        }
    }
}
