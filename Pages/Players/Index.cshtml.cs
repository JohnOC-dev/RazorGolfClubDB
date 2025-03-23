using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorGolfClubDB.Data;
using RazorGolfClubDB.Models;

namespace RazorGolfClubDB.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly RazorGolfClubDB.Data.RazorGolfClubDBContext _context;

        public IndexModel(RazorGolfClubDB.Data.RazorGolfClubDBContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Player = await _context.Player
                .Include(p => p.Booking).ToListAsync();
        }
    }
}
