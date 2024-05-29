using FinanceTracker.API.Models.Domain;

namespace FinanceTracker.API.Models.DTO
{
    public class IncomeDto
    {
        public Guid IncomeId { get; set; }
        public string UserId { get; set; }
        public string Source { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }
        public DateTime DateReceived { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }


        public IncomeDto(Income income)
        {
            IncomeId = income.IncomeId;
            UserId = income.UserId;
            Source = income.Source;
            Amount = income.Amount;
            Frequency = income.Frequency;
            DateReceived = income.DateReceived;
            PaymentMethod = income.PaymentMethod;
            Status = income.Status;
            Notes = income.Notes;

        }

    }


}
