using System.Linq.Expressions;
using TestIlcsApi.Entities;

namespace TestIlcsApi.Services;

public interface ICountryService
{
    Task<Country> Create(Country payload);
    Task<Country> GetById(string id);
    Task<Country> GetBy(Expression<Func<Country, bool>> criteria);
    Task<List<Country>> GetAll();
    Task<Country> Update(Country payload);
}