namespace SchoolProject.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using SchoolProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SchoolProject.Models.SchoolContext";
        }

        protected override void Seed(Models.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            var students = new List<Student> {
                new Student { Id = 1, Name = "Elvin", Surname = "Asadov" },
                new Student { Id = 2, Name = "Telman", Surname = "Asadov" },
                new Student { Id = 3, Name = "Rauf", Surname = "Hasanov" },
                new Student { Id = 4, Name = "Samir", Surname = "Mehdiyev" }
            };
            students.ForEach(s => context.Students.AddOrUpdate(s));

            var courses = new List<Course> {
                new Course
                {
                    Id = 1,
                    Name = "Agile for Beginners",
                    Students = new List<Student>() { students[0], students[1], students[3] }
                },
                new Course
                {
                    Id = 2,
                    Name = "Algorithms and Data Structures",
                    Students = new List<Student>() { students[2], students[3] }
                },
                new Course
                {
                    Id = 3,
                    Name = "C# in Depth",
                    Students = new List<Student>() { students[2], students[3], students[0] }
                }
            };
            courses.ForEach(c => context.Courses.AddOrUpdate(c));

            base.Seed(context);

        }
    }
}
