using Lumina.Domain.Entities;
using Lumina.Infrastructure.UnitOfWork;
using Lumina.Services.Interfaces;

namespace Lumina.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(string id)
        {
            var profile = _unitOfWork.ProfileRepository.Get(c => c.AppUserId == id);

            if (profile != null)
            {
                _unitOfWork.ProfileRepository.Remove(profile);
                _unitOfWork.Commit();
            }
        }

        public Profile Get(string id)
        {
            return _unitOfWork.ProfileRepository.Get(c => c.AppUserId == id);
        }

        public IEnumerable<Profile> GetAll()
        {
            return _unitOfWork.ProfileRepository.GetAll();
        }

        public void Insert(Profile profile)
        {
            _unitOfWork.ProfileRepository.Add(profile);
            _unitOfWork.Commit();
        }

        public void Update(Profile profile)
        {
            _unitOfWork.ProfileRepository.Update(profile);
            _unitOfWork.Commit();
        }
    }
}
