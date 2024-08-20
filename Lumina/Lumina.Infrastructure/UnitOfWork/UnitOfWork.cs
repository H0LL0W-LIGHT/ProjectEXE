using Lumina.Domain.Entities;
using Lumina.Infrastructure.Data;
using Lumina.Infrastructure.Repositories;
using Lumina.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Lumina.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly LuminaDbContext _dbContext;

		private IAppUserRepository _appUserRepository;
		private IProfileRepository _profileRepository;
		private IRoleRepository _roleRepository;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<AppUser> _userManager;


		public UnitOfWork(
			LuminaDbContext dbContext,
			RoleManager<IdentityRole> roleManager,
			UserManager<AppUser> userManager)
		{
			_dbContext = dbContext;
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public IAppUserRepository AppUserRepository
		{
			get
			{
				return _appUserRepository = _appUserRepository ?? new AppUserRepository(_dbContext);
			}
		}

		public IProfileRepository ProfileRepository
		{
			get
			{
				return _profileRepository = _profileRepository ?? new ProfileRepository(_dbContext);
			}
		}

		public IRoleRepository RoleRepository
		{
			get
			{
				return _roleRepository = _roleRepository ?? new RoleRepository(_dbContext);
			}
		}

		public async Task CommitAsync()
		{
			await _dbContext.SaveChangesAsync();
		}

		public async Task RollbackAsync()
		{
			await Task.Run(() => _dbContext.Dispose());
		}
	}
}
