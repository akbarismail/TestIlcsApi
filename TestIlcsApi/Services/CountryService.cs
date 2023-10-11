using System.Linq.Expressions;
using TestIlcsApi.Entities;
using TestIlcsApi.Repositories;

namespace TestIlcsApi.Services;

public class CountryService : ICountryService
{
    private readonly IRepository<Country> _countryRepository;
    private readonly IPersistence _persistence;

    public CountryService(IRepository<Country> countryRepository, IPersistence persistence)
    {
        _countryRepository = countryRepository;
        _persistence = persistence;
    }

    public async Task<Country> Create(Country payload)
    {
        var country = await _countryRepository.SaveAsync(payload);
        await _persistence.SaveChangesAsync();
        return country;
    }

    public async Task<Country> GetById(string id)
    {
        try
        {
            var country = await _countryRepository.FindByIdAsync(Guid.Parse(id));
            if (country is null) throw new Exception("Country is not found");
            return country;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Country> GetBy(Expression<Func<Country, bool>> criteria)
    {
        try
        {
            var country = await _countryRepository.FindAsync(criteria);
            if (country is null) throw new Exception("Country is not found");
            return country;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Country>> GetAll()
    {
        return await _countryRepository.FindAllAsync();
    }

    public async Task<Country> Update(Country payload)
    {
        var country = _countryRepository.Update(payload);
        await _persistence.SaveChangesAsync();
        return country;
    }
}