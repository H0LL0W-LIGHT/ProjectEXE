using Lumina.Domain.Entities;

namespace Lumina.Services.Interfaces
{
	public interface IProfileService
	{
		Task<IEnumerable<Profile>> GetAllAsync();
		Task<Profile> GetAsync(string id);
		Task InsertAsync(Profile profile);
		Task UpdateAsync(Profile profile);
		Task DeleteAsync(string id);
	}
}
