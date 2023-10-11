using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TestIlcsApi.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> SaveAsync(TEntity entity)
    {
        var entityEntry = await _context.Set<TEntity>().AddAsync(entity);
        return entityEntry.Entity;
    }

    public TEntity Attach(TEntity entity)
    {
        var entityEntry = _context.Set<TEntity>().Attach(entity);
        return entityEntry.Entity;
    }

    public async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(criteria);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria, IEnumerable<string> includes)
    {
        var queryable = _context.Set<TEntity>().AsQueryable();
        foreach (var include in includes)
        {
            queryable = queryable.Include(include);
        }

        return await queryable.FirstOrDefaultAsync(criteria);
    }

    public async Task<List<TEntity>> FindAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria)
    {
        return await _context.Set<TEntity>().Where(criteria).ToListAsync();
    }

    public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, IEnumerable<string> includes)
    {
        var queryable = _context.Set<TEntity>().AsQueryable();
        foreach (var include in includes)
        {
            queryable = queryable.Include(include);
        }

        return await _context.Set<TEntity>().Where(criteria).ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
        var attach = Attach(entity);
        _context.Set<TEntity>().Update(attach);
        return attach;
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}