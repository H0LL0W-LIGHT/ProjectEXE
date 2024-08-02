using JustBlog.Infrastructure;
using Lumina.Domain.Entities;
using Lumina.Infrastructure.Data;
using Lumina.Infrastructure.Repositories.Interfaces;

namespace Lumina.Infrastructure.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(LuminaDbContext dbContext) : base(dbContext)
        {

        }
    }
}
