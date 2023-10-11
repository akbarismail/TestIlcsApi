using System.Linq.Expressions;
using TestIlcsApi.Entities;

namespace TestIlcsApi.Services;

public interface IPpnService
{
    Task<Ppn> Create(Ppn payload);
    Task<Ppn> GetBy(Expression<Func<Ppn, bool>> criteria, IEnumerable<string> includes);
    Task<Ppn> Update(Ppn payload);
}