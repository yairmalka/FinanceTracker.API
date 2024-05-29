using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{
    public class Portfolio
    {
        [Key]
        public Guid PortfolioId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public decimal TotalValue { get; set; }

    }
}
