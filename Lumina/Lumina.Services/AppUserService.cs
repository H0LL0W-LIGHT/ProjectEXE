using Lumina.Domain.Entities;
using Lumina.Infrastructure.UnitOfWork;
using Lumina.Services.Interfaces;

namespace Lumina.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(string id)
        {
            var appUser = _unitOfWork.AppUserRepository.Get(c => c.Id == id);

            if (appUser != null)
            {
                _unitOfWork.AppUserRepository.Remove(appUser);
                _unitOfWork.Commit();
            }
        }

        public AppUser Get(string id)
        {
            return _unitOfWork.AppUserRepository.Get(c => c.Id == id);
        }

        public IEnumerable<AppUser> GetAll()
        {
            return _unitOfWork.AppUserRepository.GetAll();
        }

        public void Insert(AppUser appUser)
        {
            _unitOfWork.AppUserRepository.Add(appUser);
            _unitOfWork.Commit();
        }

        public void Update(AppUser appUser)
        {
            _unitOfWork.AppUserRepository.Update(appUser);
            _unitOfWork.Commit();
        }
    }
}
