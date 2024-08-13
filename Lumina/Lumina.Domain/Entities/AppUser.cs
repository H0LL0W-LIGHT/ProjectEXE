using Microsoft.AspNetCore.Identity;

namespace Lumina.Domain.Entities
{
	public class AppUser : IdentityUser
	{
		public string? CreatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string? ModifiedBy { get; set; }
		public DateTime? ModifiedOn { get; set; }

		// Navigation properties for the creator and modifier
		public AppUser? Creator { get; set; }
		public AppUser? Modifier { get; set; }

		// Navigation property for UserProfile
		public Profile? Profile { get; set; }
	}
}
