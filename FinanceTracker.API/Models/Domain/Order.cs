﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FinanceTracker.API.Models.Enums.OrderEnums;

namespace FinanceTracker.API.Models.Domain
{ 

    public class Order
    {
    [Key]
    public Guid OrderId { get; set; }
    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }
    public Guid InstrumentId {get; set; }
    [ForeignKey("InstrumentId")]
    public virtual Instrument Instrument { get; set; }
    public string TickerSymbol { get; set; }
    public OrderAction OrderAction {  get; set; } 
    public OrderType OrderType { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public decimal LimitPrice { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
    public decimal Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public string StatusMessage { get; set; }
    }


}
