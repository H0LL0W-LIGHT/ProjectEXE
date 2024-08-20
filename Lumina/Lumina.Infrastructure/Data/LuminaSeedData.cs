using Lumina.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Lumina.Infrastructure.Data
{
	public static class LuminaSeedData
	{
		public static async Task SeedRolesAndAdminUser(
		RoleManager<IdentityRole> roleManager,
		UserManager<AppUser> userManager)
		{
			// Define the roles you want to create
			var roles = new List<string> { "Admin", "User", "Manager" };

			// Create roles if they don't exist
			foreach (var role in roles)
			{
				if (!await roleManager.RoleExistsAsync(role))
				{
					await roleManager.CreateAsync(new IdentityRole(role));
				}
			}

			// Define the admin user details
			var adminUserEmail = "admin@example.com";
			var adminPassword = "Admin123@";

			// Check if the admin user exists
			var adminUser = await userManager.FindByEmailAsync(adminUserEmail);

			if (adminUser == null)
			{
				// Create the admin user
				adminUser = new AppUser
				{
					UserName = adminUserEmail,
					Email = adminUserEmail,
					EmailConfirmed = true
				};

				var result = await userManager.CreateAsync(adminUser, adminPassword);

				// If user creation succeeded, assign the user to the "Admin" role
				if (result.Succeeded)
				{
					await userManager.AddToRoleAsync(adminUser, "Admin");
				}
			}
		}
	}
}
