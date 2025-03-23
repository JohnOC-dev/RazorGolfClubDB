using System.ComponentModel.DataAnnotations;

namespace RazorGolfClubDB.Models
{
    public class Member
    {
        [Required(ErrorMessage = "Membership Number is required.")]
        public int MemberID { get; set; } // Primary key
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Handicap is required.")]
        [Range(0, 50, ErrorMessage = "Handicap must be between 0 and 50.")]
        public int Handicap { get; set; }
        // Navigation property to Bookings (one-to-many relationship)
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }

}
