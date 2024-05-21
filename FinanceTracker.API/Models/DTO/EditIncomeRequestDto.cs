using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Models.DTO
{
    public class EditIncomeRequestDto
    {
        public string Source { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }
        public DateTime DateReceived { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }

    }
}
