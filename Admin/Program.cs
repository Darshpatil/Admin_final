/*//using Admin.Data;
//using Admin.Models;
using AdminDAL;

using AdminDAL.Context;
using AdminDAL.Entities;
using AdminDAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            ConfigureServices(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

            builder.Services.AddDbContext<AdminContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=AdminM}/{action=Login}/{id?}");

            app.Run();

        }
            private static void ConfigureServices(IServiceCollection services, string constring = "")
            {



            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();

                // Registering FeatureRepository with the generic IRepository
                ////services.AddScoped<IRepository<Feature>, FeatureRepository>();
                // Inside ConfigureServices method in Startup.cs
                services.AddScoped<IFeatureRepository, FeatureRepository>();

                // Registering GenericRepository for other entities
                services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

                services.AddDbContext<AdminContext>(options => options.UseSqlServer(constring));
            }
        }
    } 
*/




using AdminDAL;
using AdminDAL.Context;
using AdminDAL.Entities2;
using AdminDAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Admin
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

            var app = builder.Build();

            Configure(app, app.Environment);

            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, string constring = "")
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();

            services.AddScoped<IFeatureRepository, FeatureRepository>();

            services.AddDbContext<AdminCont>(options => options.UseSqlServer(constring));
        }

        private static void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=AdminM}/{action=Index}/{id?}");
        }
    }
}
