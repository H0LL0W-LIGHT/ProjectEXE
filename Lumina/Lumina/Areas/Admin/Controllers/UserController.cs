using Lumina.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lumina.WebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/User")]
	public class UserController : Controller
	{
		// GET: CategoriesController
		private readonly IAppUserRepository _appUserRepository;

		public UserController(IAppUserRepository appUserRepository)
		{
			_appUserRepository = appUserRepository;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			return View(await _appUserRepository.GetAllAsync());
		}
	}
}
