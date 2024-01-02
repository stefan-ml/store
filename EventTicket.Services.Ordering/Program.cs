using EventTicket.Services.Ordering;
using EventTicket.Services.Ordering.DbContexts;
using EventTicket.Services.Ordering.Messages;
using EventTicket.Services.Ordering.Messaging;
using EventTicket.Services.Ordering.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnDbStr"));
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

//Specific DbContext for use from singleton AzServiceBusConsumer
var optionsBuilder = new DbContextOptionsBuilder<OrderDbContext>();
optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("ConnDbStr"));

builder.Services.AddSingleton(new OrderRepository(optionsBuilder.Options));

builder.Services.AddSingleton<IMessageBus, RabbitMQMessageBus>();
builder.Services.AddSingleton<IRabbitMQConsumer, RabbitMQConsumer>();
builder.Services.AddHostedService<Worker>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy =>
        {
            policy.AllowAnyOrigin() // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors("CorsPolicy");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
