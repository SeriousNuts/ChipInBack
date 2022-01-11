using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChipIn.Controller.Models;
using Microsoft.EntityFrameworkCore;

namespace ChipIn.Controller.Data
{
    public class ChipInControllerContext : DbContext
    {
        public ChipInControllerContext (DbContextOptions<ChipInControllerContext> options)
            : base(options)
        {
        }

        public DbSet<User_> User_ { get; set; }

        public DbSet<Member> Member { get; set; }

        public DbSet<Event> Event { get; set; }
    }
}
