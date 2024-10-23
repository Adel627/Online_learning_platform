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

            builder.Entity<Categories>().HasData(
             new Categories { ID = 1, Name = "Backend", Img = "download (2).jpeg" },
             new Categories { ID = 2, Name = "Frontend", Img = "frontend.png" }
              );
            builder.Entity<Trainer>().HasData(
            new Trainer { Id = 1, Name = "Mohamed", Description = "I am a Backend Developer in xqt company and work as instructor", Img = "images (1).jpeg", Email = "mohamed23@gmail.com", },
            new Trainer { Id = 2, Name = "Ahmed", Description = "I am a Frontend Developer in solution  company and work as instructor", Img = "ahmedemp.jpg", Email = "ahmed78@gmail.com", },
            new Trainer { Id = 3, Name = "Camelia", Description = "I am a Ui&Ux Developer in soft company and work as instructor", Img = "empimg.jpeg", Email = "camelia90@gmail.com", }
             );
            builder.Entity<Courses>().HasData(
                new Courses {  CoursesId = 1,   Name = "C#", CreationDate = new DateTime(2024, 10, 2, 14, 30, 00), Description = "in this course you will learn all concepts of c# language",Img = "csharp.png",  CategoryId = 1, TrainerId = 1,},
                new Courses { CoursesId = 2, Name = "Data Base", CreationDate = new DateTime(2024, 10, 10, 14, 30, 00), Description = "in this course you will learn all concepts of Data bases with Sql server", Img = "Sql.jpeg", CategoryId = 1, TrainerId = 1 },
                new Courses { CoursesId = 3, Name = "Linq", CreationDate = new DateTime(2024, 10, 12, 14, 30, 00), Description = "in this course you will learn all concepts of how to query data using linq library", Img = "Linq.jpeg", CategoryId = 1, TrainerId = 1 },
                new Courses { CoursesId = 4, Name = "EF core", CreationDate = new DateTime(2024, 10, 22, 14, 30, 00), Description = "in this course you will learn all concepts of how to conect with database from vs and building database with c#", Img = "EF.jpeg", CategoryId = 1, TrainerId = 1 },
                new Courses { CoursesId = 5, Name = "HTML", CreationDate = new DateTime(2024, 10, 13, 14, 30, 00), Description = "in this course you will learn all concepts of how to build the skeleton of the page ", Img = "Html.jpeg", CategoryId = 2, TrainerId = 3 },
                new Courses { CoursesId = 6, Name = "CSS", CreationDate = new DateTime(2024, 10, 16, 14, 30, 00), Description = "in this course you will learn all concepts of how to style page elements", Img = "Css.jpeg", CategoryId = 2, TrainerId = 3 },
                new Courses { CoursesId = 7, Name = "JS", CreationDate = new DateTime(2024, 10, 22, 14, 30, 00), Description = "in this course you will learn all concepts of how to make the page dynamic ", Img = "Js.png", CategoryId = 2, TrainerId = 3 }
                );
            builder.Entity<Lesson>().HasData(
                
                new Lesson { Lesson_Id = 1 ,Title= "introduction",Description="introduction to c#",Video= "https://youtu.be/DZHohhJDjHk?si=ntxasWbbdiUK8vwu",CreationDate= new DateTime(2024, 10, 12, 14, 30, 00),CoursesId=1 },
                new Lesson { Lesson_Id = 2 ,Title= "Language Syntax",Description="Learn the basic syntax of lthe language ",Video= "https://youtu.be/ArvFgo9wM3M?si=CuVFmK8AZJssrLer", CreationDate= new DateTime(2024, 10, 12, 14, 30, 00),CoursesId=1 },
                new Lesson { Lesson_Id = 3 ,Title= "Writen to console",Description="we will learn how to write to console and display it",Video= "https://youtu.be/xP1vT4Qpw1w?si=0S-5WCbTDDhZALhl", CreationDate= new DateTime(2024, 10, 12, 14, 30, 00),CoursesId=1 },
                new Lesson { Lesson_Id = 4 ,Title= "variables",Description="in this lesson you will learn the kind of variables , his scopes and how to use it ",Video= "https://youtu.be/Mc74_yTAK3Y?si=7b8GuFSXXaVfe4sA", CreationDate= new DateTime(2024, 10, 12, 14, 30, 00),CoursesId=1 },
                new Lesson { Lesson_Id = 5 ,Title= "Data Types",Description="you will learn the kinds of data types and the using of it ",Video= "https://youtu.be/TchQzL53Fs0?si=cPNVtPtShT9WxK5S", CreationDate= new DateTime(2024, 10, 12, 14, 30, 00),CoursesId=1 }
                
                );

            

            base.OnModelCreating(builder);
        }


    }
}
