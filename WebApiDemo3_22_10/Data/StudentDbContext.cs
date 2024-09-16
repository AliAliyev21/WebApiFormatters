using Microsoft.EntityFrameworkCore;
using WebApiDemo3_22_10.Entities;

namespace WebApiDemo3_22_10.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            :base(options)
        {
        }
        public DbSet<Student> Students{ get; set; }
    }
}
