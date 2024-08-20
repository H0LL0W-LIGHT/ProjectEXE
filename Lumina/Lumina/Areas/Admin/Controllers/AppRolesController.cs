using Lumina.Infrastructure.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lumina.WebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Roles")]
	[Authorize(Policy = nameof(Policies.ManageRolesPolicy))]
	public class AppRolesController : Controller
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		public AppRolesController(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
