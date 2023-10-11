using System.Linq.Expressions;
using TestIlcsApi.Entities;
using TestIlcsApi.Repositories;

namespace TestIlcsApi.Services;

public class HarbourService : IHarbourService
{
    private readonly IRepository<Harbour> _harbourRepository;
    private readonly IPersistence _persistence;

    public HarbourService(IRepository<Harbour> harbourRepository, IPersistence persistence)
    {
        _harbourRepository = harbourRepository;
        _persistence = persistence;
    }
    
    public async Task<Harbour> Create(Harbour payload)
    {
            var harbour = await _harbourRepository.SaveAsync(payload);
            await _persistence.SaveChangesAsync();
            return harbour;
    }

    public async Task<Harbour> GetById(string id)
    {
        var harbour = await _harbourRepository.FindByIdAsync(Guid.Parse(id));
        if (harbour == null) throw new Exception("Harbour is not found");
        return harbour;
    }

    public async Task<Harbour> GetBy(Expression<Func<Harbour, bool>> criteria, IEnumerable<string> includes)
    {
        var harbour = await _harbourRepository.FindAsync(criteria, includes);
        if (harbour == null) throw new Exception("Harbour is not found");
        return harbour;
    }

    public async Task<Harbour> Update(Harbour payload)
    {
        var harbour = _harbourRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return harbour;
    }
}