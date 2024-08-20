using Lumina.Domain.Entities;
using Lumina.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Lumina.Services
{
	public class RoleService : IRoleService
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;

		public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		// Role operations

		public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
		{
			return _roleManager.Roles;
		}

		public async Task<IdentityRole> GetRoleByIdAsync(string id)
		{
			return await _roleManager.FindByIdAsync(id);
		}

		public async Task<IdentityRole> CreateRoleAsync(string roleName)
		{
			var role = new IdentityRole(roleName);
			var result = await _roleManager.CreateAsync(role);

			if (result.Succeeded)
			{
				return role;
			}
			throw new Exception("Role creation failed");
		}

		public async Task DeleteRoleAsync(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);
			if (role != null)
			{
				var result = await _roleManager.DeleteAsync(role);

				if (!result.Succeeded)
				{
					throw new Exception("Role deletion failed");
				}
			}
		}

		// User role operations

		public async Task AssignRoleToUserAsync(string userId, string roleName)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user != null)
			{
				var result = await _userManager.AddToRoleAsync(user, roleName);

				if (!result.Succeeded)
				{
					throw new Exception("Role assignment failed");
				}
			}
		}

		public async Task RemoveRoleFromUserAsync(string userId, string roleName)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user != null)
			{
				var result = await _userManager.RemoveFromRoleAsync(user, roleName);

				if (!result.Succeeded)
				{
					throw new Exception("Role removal failed");
				}
			}
		}

		public async Task<IEnumerable<string>> GetUserRolesAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user != null)
			{
				return await _userManager.GetRolesAsync(user);
			}
			return Enumerable.Empty<string>();
		}
	}
}
