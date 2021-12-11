using System;
using System.Collections.Generic;

namespace ChipIn.models
{
    public class Event
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Deadline { get; set; }
        public string? CreditorName { get; set; }
        public decimal? FullAmount { get; set; }
        public int[]? Members { get; set; }
    }
}
