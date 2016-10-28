using System;
using System.Collections.Generic;
using UniversityManagementSystem.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.DAL
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext() : base("UniversityConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<UniversityManagementSystem.Models.AssignCourse>()
            //    .HasRequired(c => c.Department).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversityDbContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Designation> Designations { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<UniversityManagementSystem.Models.AssignCourse> AssignCourses { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomAllocation> RoomAllocations { get; set; }

        public DbSet<Day> Days { get; set; }

        public System.Data.Entity.DbSet<UniversityManagementSystem.Models.EnrollCourse> EnrollCourses { get; set; }

        public System.Data.Entity.DbSet<UniversityManagementSystem.Models.ResultEntry> ResultEntries { get; set; }

        public System.Data.Entity.DbSet<UniversityManagementSystem.Models.Grade> Grades { get; set; }
    }
}