using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorGolfClubDB.Data;
using RazorGolfClubDB.Models;

namespace RazorGolfClubDB.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly RazorGolfClubDB.Data.RazorGolfClubDBContext _context;

        public IndexModel(RazorGolfClubDB.Data.RazorGolfClubDBContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Booking = await _context.Booking
                .Include(b => b.Member).ToListAsync();
        }
    }
}
