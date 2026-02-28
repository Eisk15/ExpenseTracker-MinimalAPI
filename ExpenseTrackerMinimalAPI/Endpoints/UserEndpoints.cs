namespace ExpenseTrackerMinimalAPI.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapGet("/", () =>
            {
                return "This is the default route";
            });
        }
    }
}
