using System.ComponentModel.DataAnnotations;

namespace RazorGolfClubDB.Models
{
    public class Player
    {
        public int PlayerId { get; set; } // Primary key
        [Required(ErrorMessage = "Player name is required.")]
        public string Name { get; set; } // Player's name
        [Required(ErrorMessage = "Handicap is required.")]
        [Range(0, 50, ErrorMessage = "Handicap must be between 0 and 50.")]
        public int Handicap { get; set; } // Player's handicap
                                          // Foreign key to Booking
        public int BookingId { get; set; }
        // Navigation property to Booking (many-to-one relationship)
        public Booking? Booking { get; set; }
    }
}


