namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Course", "SemesterId", "dbo.Semester");
            DropIndex("dbo.Course", new[] { "SemesterId" });
            AddColumn("dbo.Course", "CourseSemister_SemesterId", c => c.Int());
            AddColumn("dbo.Course", "Semester_SemesterId", c => c.Int());
            CreateIndex("dbo.Course", "CourseSemister_SemesterId");
            CreateIndex("dbo.Course", "Semester_SemesterId");
            AddForeignKey("dbo.Course", "CourseSemister_SemesterId", "dbo.Semester", "SemesterId");
            AddForeignKey("dbo.Course", "Semester_SemesterId", "dbo.Semester", "SemesterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Course", "Semester_SemesterId", "dbo.Semester");
            DropForeignKey("dbo.Course", "CourseSemister_SemesterId", "dbo.Semester");
            DropIndex("dbo.Course", new[] { "Semester_SemesterId" });
            DropIndex("dbo.Course", new[] { "CourseSemister_SemesterId" });
            DropColumn("dbo.Course", "Semester_SemesterId");
            DropColumn("dbo.Course", "CourseSemister_SemesterId");
            CreateIndex("dbo.Course", "SemesterId");
            AddForeignKey("dbo.Course", "SemesterId", "dbo.Semester", "SemesterId");
        }
    }
}
