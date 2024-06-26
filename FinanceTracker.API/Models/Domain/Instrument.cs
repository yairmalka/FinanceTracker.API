﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace FinanceTracker.API.Models.Domain
{
    public class Instrument
    {
        [Key]
        public Guid InstrumentId { get; set; }
        public string TickerSymbol { get; set; }
        public string Name { get; set; }
        public decimal CurrentPrice { get; set; }
        
        public string Country { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Currency {  get; set; }

    }
}

