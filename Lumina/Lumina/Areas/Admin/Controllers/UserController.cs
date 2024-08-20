using Lumina.Domain.Entities;
using Lumina.Infrastructure.Repositories.Interfaces;
using Lumina.WebApp.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lumina.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    /*    [Authorize(Policy = nameof(Policies.ManageUsersPolicy))]
    */
    public class UserController : Controller
    {
        // GET: CategoriesController
        private readonly IAppUserRepository _appUserRepository;

        public UserController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        [Route("Index")]
        public async Task<IActionResult> Index(int pageNumber, int pageSize)
        {
            if (pageSize <= 0)
            {
                pageSize = 1;
            }

            if (pageNumber < 1) //page < 1;
            {
                pageNumber = 1; //page ==1
            }

            IEnumerable<AppUser> appUsers = await _appUserRepository.GetPagedAsync(pageNumber, pageSize);

            int recsCount = await _appUserRepository.CountRecordAsync();

            var pager = new Paginate(recsCount, pageNumber, pageSize);

            ViewBag.Pager = pager;

            return View(appUsers);
        }
    }
}
