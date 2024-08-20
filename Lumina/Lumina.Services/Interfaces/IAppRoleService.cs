using Lumina.Domain.Entities;

namespace Lumina.Services.Interfaces
{
	public interface IAppRoleService
	{
		Task<IEnumerable<AppUser>> GetAllAsync();
		Task<AppUser> GetAsync(string id);
		Task InsertAsync(AppUser appUser);
		Task UpdateAsync(AppUser appUser);
		Task DeleteAsync(string id);
	}
}
