using Microsoft.EntityFrameworkCore;
using RazorGolfClubDB.Models;
using RazorGolfClubDB.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorGoLfClubDB.Services
{
    public class MemberService
    {
        private readonly RazorGolfClubDBContext _context;

        public MemberService(RazorGolfClubDBContext context)
        {
            _context = context;
        }

        // Get all members
        public async Task<List<Member>> GetAllMembersAsync()
        {
            return await _context.Member.ToListAsync();
        }

        // Filter members by gender
        public async Task<List<Member>> GetMembersByGenderAsync(string gender)
        {
            return await _context.Member
                .Where(m => m.Gender == gender)
                .ToListAsync();
        }

        // Filter members by handicap range
        public async Task<List<Member>> GetMembersByHandicapRangeAsync(string range)
        {
            IQueryable<Member> query = _context.Member;

            switch (range)
            {
                case "below10":
                    query = query.Where(m => m.Handicap < 10);
                    break;
                case "11to20":
                    query = query.Where(m => m.Handicap >= 11 && m.Handicap <= 20);
                    break;
                case "above20":
                    query = query.Where(m => m.Handicap > 20);
                    break;
            }

            return await query.ToListAsync();
        }

        // Get bookings for a specific member
        public async Task<List<Booking>> GetBookingsByMemberIdAsync(int memberId)
        {
            return await _context.Booking
                .Include(b => b.Players)
                .Where(b => b.MemberId == memberId)
                .ToListAsync();
        }
    }
}