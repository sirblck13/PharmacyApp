using System.Linq.Expressions;

namespace Dal.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Blocking

        IEnumerable<TEntity> GetAll();
        
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        
        void AddRange(IEnumerable<TEntity> entities);
        
        TEntity Find(params object[] parameters);
        
        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        void UpdateRange(IEnumerable<TEntity> entities);


        #endregion

        #region Async

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> FindAsync(params object[] parameters);

        Task<IEnumerable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

    }
}
