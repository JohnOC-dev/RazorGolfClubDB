using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorGolfClubDB.Data;
using RazorGolfClubDB.Models;

namespace RazorGolfClubDB.Pages.Players
{
    public class CreateModel : PageModel
    {
        private readonly RazorGolfClubDB.Data.RazorGolfClubDBContext _context;

        public CreateModel(RazorGolfClubDB.Data.RazorGolfClubDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingId");
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Player.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
