using System.Linq.Expressions;
using TestIlcsApi.Entities;
using TestIlcsApi.Repositories;

namespace TestIlcsApi.Services;

public class PpnService : IPpnService
{
    private readonly IRepository<Ppn> _ppnRepository;
    private readonly IPersistence _persistence;

    public PpnService(IRepository<Ppn> ppnRepository, IPersistence persistence)
    {
        _ppnRepository = ppnRepository;
        _persistence = persistence;
    }

    public async Task<Ppn> Create(Ppn payload)
    {
        var entryPpn = await _ppnRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return entryPpn;
    }

    public async Task<Ppn> GetBy(Expression<Func<Ppn, bool>> criteria, IEnumerable<string> includes)
    {
        var ppn = await _ppnRepository.FindAsync(criteria, includes);
        if (ppn is null) throw new Exception("Ppn not found");
        return ppn;
    }

    public async Task<Ppn> Update(Ppn payload)
    {
        var updatePpn = _ppnRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return updatePpn;
    }
}