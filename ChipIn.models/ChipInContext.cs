using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;




namespace ChipIn.models
{
    public partial class ChipInContext : DbContext
    {
        public ChipInContext()
        {
        }

        public ChipInContext(DbContextOptions<ChipInContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

       
    }
}
