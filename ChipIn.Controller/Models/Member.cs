using ChipIn.models;
using System;
using System.Collections.Generic;

namespace ChipIn.Controller.Models
{
    public partial class Member : User
    {
        public int MemberId { get; set; }
        public double member_credit { get; set; }
       // public ICollection<Event> events { get; set; }
    }
}
