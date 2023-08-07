using Microsoft.EntityFrameworkCore;
using PicoManApi;
using PicoManApi.Data;
using PicoManApi.Interfaces;
using PicoManApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddScoped< IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IOwnerRepository,OwnerRepository>();
builder.Services.AddScoped<IPokemonOwnerRepository, PokemonOwnerRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();
builder.Services.AddScoped<IPokemonCategoryRepository,PokemonCategoryRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PocoManCon") );
});

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app); 

void SeedData(IHost app)
{
    var ScopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = ScopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }

}

    






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
