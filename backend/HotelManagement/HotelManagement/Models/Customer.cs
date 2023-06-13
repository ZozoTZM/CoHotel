using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string? Address { get; set; }

        public ICollection<Booking> Bookings { get; set; } = null!;
    }
}
