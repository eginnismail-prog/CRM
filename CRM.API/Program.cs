using CRM.DataAccess;
using Microsoft.EntityFrameworkCore;
using CRM.Business;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMusteriRepository, MusteriRepository>();
builder.Services.AddScoped<IMusteriService, MusteriService>();

builder.Services.AddScoped<IFirmaRepository, FirmaRepository>();
builder.Services.AddScoped<IFirmaService, FirmaService>();

builder.Services.AddScoped<IKategoriRepository, KategoriRepository>();
builder.Services.AddScoped<IKategoriService, KategoriService>();

builder.Services.AddScoped<IUrunRepository, UrunRepository>();
builder.Services.AddScoped<IUrunService, UrunService>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IKullaniciRepository, KullaniciRepository>();
builder.Services.AddScoped<IKullaniciService, KullaniciService>();
builder.Services.AddScoped<IFirsatRepository, FirsatRepository>();
builder.Services.AddScoped<IFirsatService, FirsatService>();
builder.Services.AddScoped<IAktiviteRepository, AktiviteRepository>();
builder.Services.AddScoped<IAktiviteService, AktiviteService>();
builder.Services.AddScoped<ITeklifRepository, TeklifRepository>();
builder.Services.AddScoped<ITeklifService, TeklifService>();
builder.Services.AddScoped<ISatisRepository, SatisRepository>();
builder.Services.AddScoped<ISatisService, SatisService>();
builder.Services.AddScoped<IDestekTalebiRepository, DestekTalebiRepository>();
builder.Services.AddScoped<IDestekTalebiService, DestekTalebiService>();
builder.Services.AddScoped<INotRepository, NotRepository>();
builder.Services.AddScoped<INotService, NotService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}