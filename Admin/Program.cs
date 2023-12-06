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

            services.AddDbContext<AdminContext>(options => options.UseSqlServer(constring));
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
