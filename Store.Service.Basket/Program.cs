using Microsoft.EntityFrameworkCore;
using Shop.Service.Basket.Services;
using Store.Service.Basket.DbContexts;
using Store.Service.Basket.Repositories;
using Store.Service.Basket.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketLinesRepository, BasketLinesRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBasketChangeProductRepository, BasketChangeProductRepository>();

builder.Services.AddDbContext<BasketDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnDbStr"));
});

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
