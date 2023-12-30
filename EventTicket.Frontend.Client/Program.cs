using EventTicket.Frontend.Client.Models;
using EventTicket.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register HTTP clients and singleton service
builder.Services.AddHttpClient<IEventCatalogService, EventCatalogService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:EventCatalog:Uri"]));
builder.Services.AddHttpClient<IShoppingBasketService, ShoppingBasketService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:ShoppingBasket:Uri"]));
builder.Services.AddHttpClient<IOrderService, OrderService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:Order:Uri"]));
builder.Services.AddHttpClient<IDiscountService, DiscountService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiConfigs:Discount:Uri"]));

builder.Services.AddSingleton<Settings>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=EventCatalog}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "eventCreate",
        pattern: "EventCreate/{action=Index}/{id?}");
});

app.Run();
