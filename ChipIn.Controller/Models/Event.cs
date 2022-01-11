using ChipIn.Controller.Models;
using System;
using System.Collections.Generic;

namespace ChipIn.Controller.Models
{
    public class Event
    {
        
        public int id { get; set; }
        public string? name_ { get; set; }
        public DateTime? deadline { get; set; }
        public string? CreditorName { get; set; }
        public decimal? FullAmount { get; set; }

        public virtual ICollection<Member>? members { get; set; }
        public virtual ICollection<User_>? Users { get; set; }

    }
}
