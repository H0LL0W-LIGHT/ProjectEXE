using Lumina.Domain.Entities;

namespace Lumina.Services.Interfaces
{
	public interface IAppUserService
	{
		Task<IEnumerable<AppUser>> GetAllAsync();
		Task<AppUser> GetAsync(string id);
		Task InsertAsync(AppUser appUser);
		Task UpdateAsync(AppUser appUser);
		Task DeleteAsync(string id);
	}
}
