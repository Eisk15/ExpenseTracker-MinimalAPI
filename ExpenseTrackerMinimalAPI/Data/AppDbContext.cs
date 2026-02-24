using Microsoft.EntityFrameworkCore;
using ExpenseTrackerMinimalAPI.Models;
namespace ExpenseTrackerMinimalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
