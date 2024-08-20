using Lumina.Domain.Entities;
using Lumina.Infrastructure.Data;
using Lumina.Infrastructure.Repositories.Interfaces;

namespace Lumina.Infrastructure.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(LuminaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
