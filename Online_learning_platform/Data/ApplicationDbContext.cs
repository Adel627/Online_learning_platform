using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_learning_platform.Models;
using System.Reflection.Emit;

namespace Online_learning_platform.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public DbSet<Categories>Categories  { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Lesson> lesson { get; set; }

        public DbSet<UserCourses> UserCourses { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            builder.Entity<Categories>().
                HasMany(c => c.Courses).
                WithOne(c => c.Categories).
                HasForeignKey(c => c.CategoryId);
            
            builder.Entity<Trainer>().
                HasMany(T => T.Courses).
                WithOne(c => c.Trainer).
                HasForeignKey( c => c.TrainerId);

            builder.Entity<Lesson>()
          .HasOne(l => l.Courses)          
          .WithMany(c => c.Lessons)      
          .HasForeignKey(l => l.CoursesId);

            builder.Entity<Lesson>()
            .HasKey(e => new { e.Lesson_Id, e.CoursesId });

          

            base.OnModelCreating(builder);
        }


    }
}
