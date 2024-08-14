using System.Linq.Expressions;

namespace Lumina.Domain
{
	public interface IGenericRepository<T> where T : class
	{
		Task<T> GetAsync(Expression<Func<T, bool>> expression);
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
		Task AddAsync(T entity);
		Task AddRangeAsync(IEnumerable<T> entities);

		Task UpdateAsync(T entity);
		Task UpdateRangeAsync(IEnumerable<T> entities);

		Task RemoveAsync(T entity);
		Task RemoveRangeAsync(IEnumerable<T> entities);

		Task<int> SaveChangesAsync();
	}
}
