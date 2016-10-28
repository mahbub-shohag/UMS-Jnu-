using System.Collections.Generic;
using System.Data.Entity;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class UniversityInitializer : DropCreateDatabaseIfModelChanges<UniversityDbContext>
    {
        protected override void Seed(UniversityDbContext context)
        {
            var designation = new List<Designation>
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

            room.ForEach(r => context.Rooms.Add(r));
            context.SaveChanges();


        }
    }
}