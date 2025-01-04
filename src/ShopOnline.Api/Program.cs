using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Net.Http.Headers;
using ShopOnline.Api.Data;
using ShopOnline.Api.Repositories;
using ShopOnline.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Get Config Variable
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddResponseCompression(options => {
    options.EnableForHttps = true;
});

// DbContext Service
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(config.GetConnectionString("AppConnection"),
        ServerVersion.AutoDetect(config.GetConnectionString("AppConnection")));
});

// Other Custom Services
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7219", "http://localhost:5009")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseAuthorization();

app.UseResponseCompression();

app.MapControllers();

app.Run();
