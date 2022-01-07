using System;
using System.Collections.Generic;

namespace ChipIn.models
{
    public class Event
    {
        public int id { get; set; }
        public string? name_ { get; set; }
        public DateTime? deadline { get; set; }
        public string? CreditorName { get; set; }
        public decimal? FullAmount { get; set; }
       
    }
}
