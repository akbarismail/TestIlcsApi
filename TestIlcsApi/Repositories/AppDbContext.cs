using Microsoft.EntityFrameworkCore;
using TestIlcsApi.Entities;

namespace TestIlcsApi.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Country>? Countries { get; set; }
    public DbSet<Harbour>? Harbours { get; set; }
    public DbSet<Ppn>? Ppns { get; set; }
    public DbSet<Product>? Products { get; set; }

    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}