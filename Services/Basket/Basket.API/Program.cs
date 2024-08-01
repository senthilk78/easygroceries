using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("ShoppingCart"));
builder.Services.AddDbContext<InitialData>();
builder.Services.AddCarter();
builder.Services.AddCors();
var app = builder.Build();

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:5173");
});
app.MapCarter();

app.Run();
