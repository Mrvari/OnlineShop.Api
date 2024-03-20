//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.Swagger;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//using OnlineShop.Core;
//using OnlineShop.Core.Services;
//using OnlineShop.Data;
//using OnlineShop.Services.Services;
//using System.Reflection;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Logging;

//namespace OnlineShop.Api
//{
//    public class Startup
//    {      
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration; // Fix typo here
//        }
//        public IConfiguration Configuration { get; } // Fix typo here

//        //This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddControllers();
//            services.AddScoped<UnitOfWork, UnitOfWork>();
//            services.AddTransient<IAddressInformationService, AddressInformationService>();
//            services.AddTransient<ICreditCardService, CreditCardService>();
//            services.AddTransient<ICustomerService, CustomerService>();
//            services.AddTransient<IOrderService, OrderService>();
//            services.AddTransient<IOrderHistoryService, OrderHistoryService>();
//            services.AddTransient<IPaymentInformationService, PaymentInformationService>();
//            services.AddTransient<IProductService, ProductService>();
//            services.AddTransient<IPromotionService, PromotionService>();
//            services.AddTransient<IReturnService, ReturnService>();
//            services.AddTransient<IShoppingCartService, ShoppingCartService>();
//            services.AddTransient<IStockService, StockService>();
//            services.AddDbContext<OnlineShopDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DevConnection"), x => x.MigrationsAssembly("MusicMarket.Data")));
//            services.AddSwaggerGen(options =>
//            {
//                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Music Market", Version = "v1" });
//            });
//            services.AddAutoMapper(typeof(Startup));
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseHttpsRedirection();

//            app.UseRouting();

//            app.UseAuthorization();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//            });
//            app.UseSwagger(); app.UseSwaggerUI(c =>
//            {
//                c.RoutePrefix = "";
//                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Music Market V1");
//            });

//        }
//    }
//}
