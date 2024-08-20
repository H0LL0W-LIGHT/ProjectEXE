using Lumina.Domain;
using Microsoft.AspNetCore.Identity;

namespace Lumina.Infrastructure.Repositories.Interfaces
{
	public interface IRoleRepository : IGenericRepository<IdentityRole>
	{
	}
}
