using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lumina.Domain.Entities
{
    public class Profile
    {
        [Key]
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }

        [StringLength(50, ErrorMessage = "First name must be less than 50 characters long.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name must be less than 50 characters long.")]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string ProfilePictureUrl { get; set; }

        // Navigation property
        public AppUser AppUser { get; set; }
    }
}
