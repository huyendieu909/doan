using HXQ.DoAn.Data.Context;
using HXQ.DoAn.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HXQ.DoAn.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // 🔹 Đăng ký DbContext với SQL Server
            builder.Services.AddDbContext<DoAnDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // 🔹 Cấu hình Identity (Account & Role)
            builder.Services.AddIdentity<Account, Role>()
                .AddEntityFrameworkStores<DoAnDbContext>()
                .AddDefaultTokenProviders();

            //builder.Services.ConfigureApplicationCookie(options =>
            //{
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //    options.SlidingExpiration = true;

            //    options.LoginPath = "/Login/Login";
            //    options.LogoutPath = "/Login/Logout";
            //    options.AccessDeniedPath = "/Login/AccessDenied";
            //});

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
