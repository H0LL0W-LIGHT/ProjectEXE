using Lumina.Infrastructure.Data;
using Lumina.Infrastructure.Repositories;
using Lumina.Infrastructure.Repositories.Interfaces;

namespace Lumina.Infrastructure.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly LuminaDbContext _dbContext;

		private IAppUserRepository _appUserRepository;
		private IProfileRepository _profileRepository;

		public UnitOfWork(LuminaDbContext dbContext)
		{
			_dbContext = dbContext;
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
