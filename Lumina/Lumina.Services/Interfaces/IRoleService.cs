using Microsoft.AspNetCore.Identity;

namespace Lumina.Services.Interfaces
{
	public interface IRoleService
	{
		// Role operations
		Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
		Task<IdentityRole> GetRoleByIdAsync(string id);
		Task<IdentityRole> CreateRoleAsync(string roleName);
		Task DeleteRoleAsync(string id);

		// User role operations
		Task AssignRoleToUserAsync(string userId, string roleName);
		Task RemoveRoleFromUserAsync(string userId, string roleName);
		Task<IEnumerable<string>> GetUserRolesAsync(string userId);
	}
}
