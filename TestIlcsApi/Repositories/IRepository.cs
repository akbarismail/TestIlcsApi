using System.Linq.Expressions;

namespace TestIlcsApi.Repositories;

public interface IRepository<TEntity>
{
    Task<TEntity> SaveAsync(TEntity entity);
    TEntity Attach(TEntity entity);
    Task<TEntity?> FindByIdAsync(Guid id);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria, IEnumerable<string> includes);
    Task<List<TEntity>> FindAllAsync();
    Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria);
    Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, IEnumerable<string> includes);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
}