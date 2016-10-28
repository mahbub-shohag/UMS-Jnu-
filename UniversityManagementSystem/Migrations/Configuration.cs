using System.Collections.Generic;
using UniversityManagementSystem.DAL;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UniversityManagementSystem.DAL.UniversityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UniversityManagementSystem.DAL.UniversityDbContext";
        }

        protected override void Seed(UniversityManagementSystem.DAL.UniversityDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            /*  var designation = new List<Designation>
              {
                  new Designation {Name = "Professor"},
                  new Designation {Name = "Asst. Professor"},
                  new Designation {Name = "Lecturer"},
                  new Designation {Name = "Asst. Lecturer"}
              };

              designation.ForEach(d => context.Designations.Add(d));
              context.SaveChanges();

              var grade = new List<Grade>
              {
                  new Grade {Name = "A+"},
                  new Grade {Name = "A"},
                  new Grade {Name = "B+"},
                  new Grade {Name = "B"},
                  new Grade {Name = "C+"},
                  new Grade {Name = "C"},
                  new Grade {Name = "D"},
                  new Grade {Name = "F"}
              };

              grade.ForEach(g => context.Grades.Add(g));
              context.SaveChanges();

              var day = new List<Day>
              {
                  new Day {Name = "Sunday"},
                  new Day {Name = "Monday"},
                  new Day {Name = "Tuesday"},
                  new Day {Name = "Wednesday"},
                  new Day {Name = "Thursday"},
                  new Day {Name = "Friday"},
                  new Day {Name = "Saturday"}
              };

              day.ForEach(d => context.Days.Add(d));
              context.SaveChanges();


              var semester = new List<Semester>
              {
                  new Semester {Name = "Summer 2014"},
                  new Semester {Name = "Fall 2014 "},
                  new Semester {Name = "Spring 2014"},
                  new Semester {Name = "Summer 2015"},
                  new Semester {Name = "Fall 2015"},
                  new Semester {Name = "Spring 2015"},
                  new Semester {Name = "Summer 2016"},
                  new Semester {Name = "Fall 2016"}
              };

              semester.ForEach(s => context.Semesters.Add(s));
              context.SaveChanges();


              var room = new List<Room>
              {
                  new Room {Name = "101"},
                  new Room {Name = "102"},
                  new Room {Name = "103"},
                  new Room {Name = "201"},
                  new Room {Name = "202"},
                  new Room {Name = "203"}
                
              };

            //  room.ForEach(r => context.Rooms.Add(r));
            //  context.SaveChanges();

              var course = new List<Course>
              {
                  new Course {Name = "CSE"},
                  new Course {Name = "EEE"},
                  new Course {Name = "Physics"},
                  new Course {Name = "ETE"},
                  new Course {Name = "Accounting"},
                  new Course {Name = "Pscychology"}
                
              };

              course.ForEach(c => context.Courses.Add(c));
              context.SaveChanges();*/

        }
    }
}
