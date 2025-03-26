
using BusinessLayer.Contract;
using BusinessLayer.Managers;
using BusinessLayer.Service;
using BusinessLayer.Service.Identity;
using BusinessLayer.Service.Payment;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.OrderProductRepo;
using DataAccessLayer.Repositories.OrderRepo;
using DataAccessLayer.Repositories.ProductRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IProductManager, ProductManager>();

            builder.Services.AddScoped<IOrderRepo, OrderRepo>();
            builder.Services.AddScoped<IOrderManager, OrderManager>();

            builder.Services.AddScoped<IOrderProductRepo, OrderProductRepo>();

            builder.Services.AddScoped<ITotalPriceHandler, TotalPriceHandler>();

            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<ISignInManager, SignInManager>();

            #region Payment

            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
            
            builder.Services.AddScoped<PaymentManager>();

            #endregion


            #region Make_connectionstring

            var ConnectionString = builder.Configuration.GetConnectionString("Project3");
           // var ConnectionString = "Server=db15825.public.databaseasp.net; Database=db15825; User Id=db15825; Password=M+f5!4ExLn9%; Encrypt=False; MultipleActiveResultSets=True;";
            builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options
                        .UseSqlServer(ConnectionString)
                        .LogTo(Console.WriteLine, LogLevel.Information);

                });

            #endregion
          

            #region Configration_identity


            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                    options.Password.RequireDigit = true;
                    //options.Password.RequiredLength = 6;
                    //options.Password.RequireNonAlphanumeric = false;
                    //options.Password.RequireUppercase = false;
                    //options.Password.RequireLowercase = false;
                    options.User.RequireUniqueEmail = true; // Ensure unique email addresses
            })
                .AddRoles<IdentityRole>()  // Enable role-based authorization
                .AddEntityFrameworkStores<ApplicationDbContext>() // Use your ApplicationDbContext
                .AddDefaultTokenProviders();


            //Apply cookie configration
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";  // Redirect to login page
                options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect if access denied
                options.ExpireTimeSpan = TimeSpan.FromDays(1); // Cookie expires in 1 day
                options.SlidingExpiration = true; // Extends expiration if active
            });


            #endregion


        

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();


            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
