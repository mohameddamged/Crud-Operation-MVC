using Microsoft.EntityFrameworkCore;
using MVC1.Models;
namespace MVC1.Data
{
    public class ITIContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ITIContext(DbContextOptions options):base(options) 
        {

        }
        public ITIContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=AMGED\\SQLEXPRESS;Database=MVC2;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
