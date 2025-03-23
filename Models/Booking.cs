using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace RazorGolfClubDB.Models
{
    public class Booking
    {
        public int BookingId { get; set; } // Primary key
        [Required(ErrorMessage = "Tee time is required.")]
        public DateTime TeeTime { get; set; } // Date and time of the booking
        [Required(ErrorMessage = "Member is required.")]
        public int MemberId { get; set; } // Foreign key to Member
        // Navigation property to Member (many-to-one relationship)
        public Member? Member { get; set; }
        // Navigation property to Players (one-to-many relationship)
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
