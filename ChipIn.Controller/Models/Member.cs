using System;
using System.Collections.Generic;

namespace ChipIn.Controller.Models
{
    public class Member
    {
        public int Id { get; set; }

        public double? member_credit { get; set; }
        
        public int? EventId { get; set; }
        //public Event? Event { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }

       // public User_? user { get; set; }
    }
}
