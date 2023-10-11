using Microsoft.EntityFrameworkCore;
using TestIlcsApi.Repositories;
using TestIlcsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// connection DB
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// repository
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

// persistence
builder.Services.AddTransient<IPersistence, DbPersistence>();

// services
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IHarbourService, HarbourService>();
builder.Services.AddTransient<IPpnService, PpnService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();