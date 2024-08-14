using Lumina.Infrastructure.Repositories.Interfaces;

namespace Lumina.Infrastructure.UnitOfWork
{
	public interface IUnitOfWork
	{
		IAppUserRepository AppUserRepository { get; }
		IProfileRepository ProfileRepository { get; }

		Task CommitAsync();
		Task RollbackAsync();
	}
}
