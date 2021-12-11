using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChipIn.models;

namespace ChipIn.Controller.Data
{
    public class ChipInControllerContext : DbContext
    {
        public ChipInControllerContext (DbContextOptions<ChipInControllerContext> options)
            : base(options)
        {
        }

        public DbSet<ChipIn.models.User> User { get; set; }

        public DbSet<ChipIn.models.Member> Member { get; set; }

        public DbSet<ChipIn.models.Event> Event { get; set; }
    }
}
