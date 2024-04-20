namespace FinanceTracker.API.Models.DTO
{
    public class AddExpenseCategoryRequest
    {
        public Guid Id { get; set; }
        public string CategoryExpenseName { get; set; }
    }
}
