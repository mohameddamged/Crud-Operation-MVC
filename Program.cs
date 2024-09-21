using Microsoft.EntityFrameworkCore;
using MVC1.Data;
using MVC1.Repository;

namespace MVC1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDepartmentRepo,DepartmentRepo>();
            builder.Services.AddScoped<IStudentRepo,StudentRepo>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddDbContext<ITIContext>(
                a => { a.UseSqlServer("Server=AMGED\\SQLEXPRESS;Database=MVC2;Integrated Security=True;Trust Server Certificate=True");
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}");

            app.Run();
        }
    }
}
