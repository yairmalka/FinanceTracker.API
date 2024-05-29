using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public class Income
    {
        [Key]
        public Guid IncomeId { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public string Source { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }
        public DateTime DateReceived { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }

}