using System;
using System.Collections.Generic;

namespace ChipIn.models
{
    public partial class Member
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
