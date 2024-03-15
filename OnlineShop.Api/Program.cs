using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineShop.Core;
using OnlineShop.Core.Services;
using OnlineShop.Data;
using OnlineShop.Services.Services;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<OnlineShopDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DevConnection"),
    x => x.MigrationsAssembly("OnlineShop.Data")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IAddressInformationService, AddressInformationService>();
builder.Services.AddTransient<ICreditCardService, CreditCardService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderHistoryService, OrderHistoryService>();
builder.Services.AddTransient<IPaymentInformationService, PaymentInformationService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IPromotionService, PromotionService>();
builder.Services.AddTransient<IReturnService,  ReturnService>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
builder.Services.AddTransient<IStockService, StockService>();

//builder.Services.AddEndpointsApiExplorer();

//ConfigureServices method
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //Configure method 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();

