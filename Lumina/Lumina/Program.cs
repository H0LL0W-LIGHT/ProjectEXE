using Lumina.Infrastructure.Data;
using Lumina.Infrastructure.Repositories;
using Lumina.Infrastructure.Repositories.Interfaces;
using Lumina.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Lumina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //config DbContext
            var connectionString = builder.Configuration.GetConnectionString("connectionString");

            builder.Services.AddDbContext<LuminaDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            //register UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //register service
            builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
            builder.Services.AddScoped<IProfileRepository, ProfileRepository>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
