using CarCenter.Data;
using CarCenter.Data.Common;
using CarCenter.Infrastructure;
using CarCenter.Services;
using CarCenter.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarCenterDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services
                 .AddDefaultIdentity<IdentityUser>(options =>
                 {
                     options.Password.RequireDigit = false;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequireUppercase = false;
                 })
                 .AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<CarCenterDbContext>();

            services.AddControllersWithViews();

            services.AddTransient<IRepository, Repository>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IIssueService, IssueService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
