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
    public class DetailsModel : PageModel
    {
        private readonly RazorGolfClubDB.Data.RazorGolfClubDBContext _context;

        public DetailsModel(RazorGolfClubDB.Data.RazorGolfClubDBContext context)
        {
            _context = context;
        }

        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Booking.FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                Booking = booking;
            }
            return Page();
        }
    }
}
