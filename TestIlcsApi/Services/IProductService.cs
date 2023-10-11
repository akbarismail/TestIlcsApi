using System.Linq.Expressions;
using TestIlcsApi.Entities;

namespace TestIlcsApi.Services;

public interface IProductService
{
    Task<Product> Create(Product product);
    Task<Product> GetById(string id);
    Task<Product> GetBy(Expression<Func<Product, bool>> criteria);
    Task<Product> Update(Product product);
    Task Delete(string id);
}