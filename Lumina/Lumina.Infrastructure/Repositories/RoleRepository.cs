using Lumina.Infrastructure.Data;
using Lumina.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Lumina.Infrastructure.Repositories
{
	public class RoleRepository : GenericRepository<IdentityRole>, IRoleRepository
	{
		public RoleRepository(LuminaDbContext dbContext) : base(dbContext)
		{

		}
	}
}
