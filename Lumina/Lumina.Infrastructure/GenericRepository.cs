using Lumina.Domain;
using Lumina.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly LuminaDbContext _dbContext;
    private readonly DbSet<T> _entitySet;

    public GenericRepository(LuminaDbContext dbContext)
    {
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _entitySet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _entitySet.AddRangeAsync(entities);
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
    {
        return await _entitySet.FirstOrDefaultAsync(expression);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entitySet.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
    {
        return await _entitySet.Where(expression).AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize)
    {
        return await _entitySet
            .AsNoTracking()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<T>> GetPagedAsync(Expression<Func<T, bool>> expression, int pageNumber, int pageSize)
    {
        return await _entitySet
            .Where(expression)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _entitySet.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _entitySet.UpdateRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _entitySet.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<T> entities)
    {
        _entitySet.RemoveRange(entities);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> CountRecordAsync()
    {
        return await _entitySet.CountAsync();
    }

    public async Task<int> CountRecordAsync(Expression<Func<T, bool>> expression)
    {
        return await _entitySet.Where(expression).CountAsync();
    }
}
