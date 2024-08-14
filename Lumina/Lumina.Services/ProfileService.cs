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

		public async Task<Profile> GetAsync(string id)
		{
			return await _unitOfWork.ProfileRepository.GetAsync(c => c.AppUserId == id);
		}

		public async Task<IEnumerable<Profile>> GetAllAsync()
		{
			return await _unitOfWork.ProfileRepository.GetAllAsync();
		}

		public async Task InsertAsync(Profile profile)
		{
			await _unitOfWork.ProfileRepository.AddAsync(profile);
			await _unitOfWork.CommitAsync();
		}

		public async Task UpdateAsync(Profile profile)
		{
			await _unitOfWork.ProfileRepository.UpdateAsync(profile);
			await _unitOfWork.CommitAsync();
		}

		public async Task DeleteAsync(string id)
		{
			var profile = await _unitOfWork.ProfileRepository.GetAsync(c => c.AppUserId == id);

			if (profile != null)
			{
				await _unitOfWork.ProfileRepository.RemoveAsync(profile);
				await _unitOfWork.CommitAsync();
			}
		}
	}
}
