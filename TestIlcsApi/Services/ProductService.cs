using System.Linq.Expressions;
using TestIlcsApi.Entities;
using TestIlcsApi.Repositories;

namespace TestIlcsApi.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IPersistence _persistence;

    public ProductService(IRepository<Product> productRepository, IPersistence persistence)
    {
        _productRepository = productRepository;
        _persistence = persistence;
    }

    public async Task<Product> Create(Product product)
    {
        var entryProduct = await _productRepository.SaveAsync(product);
        await _persistence.SaveChangesAsync();
        return entryProduct;
    }

    public async Task<Product> GetById(string id)
    {
        var product = await _productRepository.FindByIdAsync(Guid.Parse(id));
        if (product is null) throw new Exception("Product is not found");
        return product;
    }

    public async Task<Product> GetBy(Expression<Func<Product, bool>> criteria)
    {
        var product = await _productRepository.FindAsync(criteria);
        if (product is null) throw new Exception("Product is not found");
        return product;
    }

    public async Task<Product> Update(Product product)
    {
        var updateProduct = _productRepository.Update(product);
        await _persistence.SaveChangesAsync();
        return updateProduct;
    }

    public async Task Delete(string id)
    {
        var product = await GetById(id);
        _productRepository.Delete(product);
        await _persistence.SaveChangesAsync();
    }
}