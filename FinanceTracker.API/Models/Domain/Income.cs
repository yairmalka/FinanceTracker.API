﻿namespace FinanceTracker.API.Models.Domain
{
    public class Income
    {
        public Guid Id { get; set; }
        public string Source { get; set; }
        public decimal Amount { get; set; }
        public string Frequency { get; set; }
        public DateTime DateReceived { get; set; }
        public string Category { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
    }

}