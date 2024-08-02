using Lumina.Domain.Entities;

namespace Lumina.Services.Interfaces
{
    public interface IProfileService
    {
        IEnumerable<Profile> GetAll();
        Profile Get(string id);
        void Insert(Profile profile);
        void Update(Profile profile);
        void Delete(string id);
    }
}
