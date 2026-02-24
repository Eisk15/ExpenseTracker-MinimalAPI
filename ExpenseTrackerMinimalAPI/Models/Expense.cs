namespace ExpenseTrackerMinimalAPI.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Category Category { get; set; }
        public required string Title { get; set; }
        public decimal Amount { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
