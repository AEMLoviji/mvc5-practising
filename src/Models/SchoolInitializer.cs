using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SchoolProject.Models
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            //var teams = new List<Course>
            //{
            //    new Course{ Name="Team_1", Coach="Coach_1" },
            //    new Course{Name="Team_2", Coach="Coach_2"},
            //    new Course{Name="Team_3", Coach="Coach_3" },
            //    new Course{Name="Team_4", Coach="Coach_4" },
            //};

            //teams.ForEach(s => context.Courses.Add(s));
            //context.SaveChanges();
        }
    }
}