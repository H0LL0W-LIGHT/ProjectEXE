using Lumina.Domain.Entities;
using Lumina.Infrastructure.UnitOfWork;
using Lumina.Services.Interfaces;

namespace Lumina.Services
{
    public class AppRoleService : IAppRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeleteAsync(string id)
        {
            var appUser = await _unitOfWork.AppUserRepository.GetAsync(c => c.Id == id);

            if (appUser != null)
            {
                _unitOfWork.AppUserRepository.RemoveAsync(appUser);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<AppUser> GetAsync(string id)
        {
            return await _unitOfWork.AppUserRepository.GetAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _unitOfWork.AppUserRepository.GetAllAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.AppUserRepository.GetPagedAsync(pageNumber, pageSize);
        }

        public async Task InsertAsync(AppUser appUser)
        {
            await _unitOfWork.AppUserRepository.AddAsync(appUser);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(AppUser appUser)
        {
            _unitOfWork.AppUserRepository.UpdateAsync(appUser);
            await _unitOfWork.CommitAsync();
        }
    }
}
