using Microsoft.EntityFrameworkCore;
namespace ExpenseTrackerMinimalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
