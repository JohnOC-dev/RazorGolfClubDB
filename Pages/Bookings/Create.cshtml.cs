using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorGolfClubDB.Data;
using RazorGolfClubDB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RazorGo1fClubDB.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly RazorGolfClubDBContext _context;

        public CreateModel(RazorGolfClubDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        [BindProperty]
        public List<Player> Players { get; set; } = new List<Player>();

        public SelectList MemberOptions { get; set; }

        public IActionResult OnGet()
        {
            // Initialize the Players list with 4 empty players
            for (int i = 0; i < 4; i++)
            {
                Players.Add(new Player());
            }

            // Populate the Member dropdown with Member names
            MemberOptions = new SelectList(_context.Member, "MemberID", "Name");
            ViewData["MemberId"] = MemberOptions;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the member already has a booking on the selected date
            var existingBooking = _context.Booking
                .FirstOrDefault(b => b.MemberId == Booking.MemberId && b.TeeTime.Date == Booking.TeeTime.Date);

            if (existingBooking != null)
            {
                ModelState.AddModelError("Booking.TeeTime", "Members can only book one game per day.");
            }

            // TeeTime validation
            if (Booking.TeeTime.Minute % 15 != 0 || Booking.TeeTime.Second != 0 || Booking.TeeTime.Millisecond != 0)
            {
                ModelState.AddModelError("Booking.TeeTime", "Tee time must be in 15-minute intervals.");
            }

            if (!ModelState.IsValid)
            {
                // Log validation errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                }

                // Re-populate the Member dropdown if the model state is invalid
                MemberOptions = new SelectList(_context.Member, "MemberID", "Name");
                ViewData["MemberId"] = MemberOptions;
                return Page();
            }

            // Add the new booking to the database
            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            // Add players to the booking
            foreach (var player in Players)
            {
                if (!string.IsNullOrEmpty(player.Name))
                {
                    player.BookingId = Booking.BookingId;
                    _context.Player.Add(player);
                }
            }
            await _context.SaveChangesAsync();

            // Redirect to the Index page
            return RedirectToPage("./Index");
        }
    }
}