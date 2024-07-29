using Catalog.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Catalog"));
builder.Services.AddDbContext<CatalogInitialData>();
builder.Services.AddCors();

var app = builder.Build();

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5173");
});

// Configure the HTTP request pipeline.
app.MapCarter();

app.Run();
