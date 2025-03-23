using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorGolfClubDB.Data;
using RazorGolfClubDB.Models;
using RazorGoLfClubDB.Services;

namespace RazorGoLfClubDB.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly MemberService _memberService;

        public IndexModel(MemberService memberService)
        {
            _memberService = memberService;
        }

        public IList<Member> Member { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string GenderFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string HandicapRangeFilter { get; set; }


        [BindProperty(SupportsGet = true)]
        public int? MemberIdFilter { get; set; }
        public List<Booking> MemberBookings { get; set; }


        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(GenderFilter))
            {
                Member = await _memberService.GetMembersByGenderAsync(GenderFilter);
            }
            else if (!string.IsNullOrEmpty(HandicapRangeFilter))
            {
                Member = await _memberService.GetMembersByHandicapRangeAsync(HandicapRangeFilter);
            }
            else if (MemberIdFilter.HasValue)
            {
                MemberBookings = await _memberService.GetBookingsByMemberIdAsync(MemberIdFilter.Value);
            }
            else
            {
                Member = await _memberService.GetAllMembersAsync();
            }
        }
    }
}
