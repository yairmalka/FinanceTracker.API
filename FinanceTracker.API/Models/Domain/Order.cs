using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Models.Domain
{ 
    public enum OrderAction
    {
        Buy,
        Sell
    }
    public enum OrderType
    {
        Limit,
        Market
    }

    public class Order
    {
    [Key]
    public Guid OrderTypeId { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }
    public Guid InstrumentId {  get; set; }
    [ForeignKey("InstrumentId")]
    public virtual Instrument Instrument { get; set; }
    public OrderAction OrderAction {  get; set; } 
    public OrderType OrderType { get; set; }
    public decimal LimitPrice { get; set; }
    public decimal Quantity { get; set; }
    }


}
