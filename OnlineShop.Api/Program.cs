using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineShop.Core;
using OnlineShop.Core.Services;
using OnlineShop.Data;
using OnlineShop.Services.Services;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add DbContext
builder.Services.AddDbContext<OnlineShopDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DevConnection"),
        sqlServerOptions => {
            sqlServerOptions.MigrationsAssembly("OnlineShop.Data");
        });
});

// Add services to the container.
builder.Services.AddControllers();

// Add support to logging with Serilog
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

// Add scoped services
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAddressInformationService, AddressInformationService>();
builder.Services.AddTransient<ICreditCardService, CreditCardService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IPaymentInformationService, PaymentInformationService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IReturnedProductService, ReturnedProductService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
builder.Services.AddTransient<IStockService, StockService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // Configure method 
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

// Add support to logging requests with Serilog
app.UseSerilogRequestLogging();

app.UseRouting();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();