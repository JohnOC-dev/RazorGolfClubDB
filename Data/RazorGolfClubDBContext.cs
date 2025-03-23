using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorGolfClubDB.Models;

namespace RazorGolfClubDB.Data
{
    public class RazorGolfClubDBContext : DbContext
    {
        public RazorGolfClubDBContext (DbContextOptions<RazorGolfClubDBContext> options)
            : base(options)
        {
        }

        public DbSet<RazorGolfClubDB.Models.Booking> Booking { get; set; } = default!;
        public DbSet<RazorGolfClubDB.Models.Member> Member { get; set; } = default!;
        public DbSet<RazorGolfClubDB.Models.Player> Player { get; set; } = default!;
    }
}
