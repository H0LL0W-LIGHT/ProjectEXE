using Lumina.Domain.Entities;

namespace Lumina.Services.Interfaces
{
    public interface IAppUserService
    {
        IEnumerable<AppUser> GetAll();
        AppUser Get(string id);
        void Insert(AppUser appUser);
        void Update(AppUser appUser);
        void Delete(string id);
    }
}
