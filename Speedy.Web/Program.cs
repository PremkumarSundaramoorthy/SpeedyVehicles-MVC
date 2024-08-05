using Microsoft.EntityFrameworkCore;
using Speedy.Application.Contracts.Presistence;
using Speedy.Infrastructure.Common;
using Speedy.Infrastructure.Data;
using Speedy.Infrastructure.Repositories;
using Speedy.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace Speedy.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configuration for Seeding Data to Database

            static async void UpdateDatabaseAsync(IHost host)
            {

                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var context = services.GetRequiredService<ApplicationDbContext>();

                        if (context.Database.IsSqlServer())
                        {
                            context.Database.Migrate();
                        }

                        await SeedData.SeedDataAsync(context);
                    }
                    catch (Exception ex)
                    {
                        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                    }
                }

            }

            #endregion

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Add Database services
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            var serviceProvider = app.Services;

            await SeedData.SeedRole(serviceProvider);

            UpdateDatabaseAsync(app);

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}