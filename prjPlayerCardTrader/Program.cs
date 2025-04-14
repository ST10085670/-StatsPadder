using Microsoft.EntityFrameworkCore;
using prjPlayerCardTrader.Data;

namespace prjPlayerCardTrader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbConnect>(options =>
            {
                options.UseSqlServer(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING"));
            });


            var app = builder.Build();

           
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
             name: "default",
             pattern: "{controller=User}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
