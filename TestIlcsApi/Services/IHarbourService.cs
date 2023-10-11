using System.Linq.Expressions;
using TestIlcsApi.Entities;

namespace TestIlcsApi.Services;

public interface IHarbourService
{
    Task<Harbour> Create(Harbour payload);
    Task<Harbour> GetById(string id);
    Task<Harbour> GetBy(Expression<Func<Harbour, bool>> criteria, IEnumerable<string> includes);
    Task<Harbour> Update(Harbour payload);
}