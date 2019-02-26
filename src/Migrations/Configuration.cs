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

            AddStudentsAndCourses(context);
            AddTreeItems(context);
            context.SaveChanges();

            base.Seed(context);
        }

        private static void AddTreeItems(SchoolContext context)
        {
            var treeItems = new List<TreeItem>
            {
                new TreeItem{Id=1, Label = "Parent_!", Order = 1},
                new TreeItem{Id=2, Label = "Parent_2", Order = 2},
                new TreeItem{Id=3, Label = "Parent_3", Order = 3},
                new TreeItem{Id=4, Label = "Child_1", Order = 1, ParentId = 2},
                new TreeItem{Id=5, Label = "Child_2", Order = 2, ParentId = 2},
                new TreeItem{Id=6, Label = "Child_3", Order = 3, ParentId = 2},
                new TreeItem{Id=7, Label = "Child_1_1", Order = 1, ParentId = 4},
                new TreeItem{Id=8, Label = "Child_1_2", Order = 2, ParentId = 4},
                new TreeItem{Id=9, Label = "Child_1_2", Order = 3, ParentId = 4}
            };
            treeItems.ForEach(t => context.TreeItems.AddOrUpdate(t));
        }

        private static void AddStudentsAndCourses(SchoolContext context)
        {
            var students = new List<Student> {
                new Student { Id = 1, Name = "Elvin", Surname = "Asadov" },
                new Student { Id = 2, Name = "Telman", Surname = "Asadov" },
                new Student { Id = 3, Name = "Rauf", Surname = "Mehdiyev" },
                new Student { Id = 4, Name = "Samir", Surname = "Hasanov" }
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
        }
    }
}
