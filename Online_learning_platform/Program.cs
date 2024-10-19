using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Online_learning_platform.Areas.Admin.Repositores;
using Online_learning_platform.Data;
using Online_learning_platform.Models;

namespace Online_learning_platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>(
            (options) =>
                    {
                         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                    }
            );

            builder.Services.AddScoped
               <CrudRepository<Categories>>();
            builder.Services.AddScoped
               <CrudRepository<Trainer>>();
            builder.Services.AddScoped
               <CourseRepository>();
            builder.Services.AddScoped
              <LessonRepository>();

            builder.Services.AddIdentity
             <ApplicationUser, IdentityRole>()
               .AddRoles<IdentityRole>()
           .AddEntityFrameworkStores<ApplicationDbContext>();

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
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
       

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Register}/{id?}");
        

            app.Run();
        }
    }
}
