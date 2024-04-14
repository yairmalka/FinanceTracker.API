namespace FinanceTracker.API.Models.Domain
{
    public class Expense
    {
        public Guid Id { get; set; }
        public DateTime DateOfExpense { get; set; }
        public decimal Amount {  get; set; }
        public string Category { get; set; }
        //public User UserID { get; set; } FIX IT: in the future after creating the user class
        public string ReceiptImageUrl { get; set; }
        public string Currency {  get; set; }
        public string Location { get; set; }   

    }
}
