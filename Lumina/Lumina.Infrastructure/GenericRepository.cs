using Lumina.Domain;
using Lumina.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JustBlog.Infrastructure
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly LuminaDbContext _dbContext;
        private readonly DbSet<T> _entitySet;

        public GenericRepository(LuminaDbContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _dbContext.AddRange(entities);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _entitySet.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _entitySet.AsEnumerable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _entitySet.Where(expression).AsEnumerable();
        }

        public void Remove(T entity)
        {
            _dbContext.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.UpdateRange(entities);
        }
    }
}
