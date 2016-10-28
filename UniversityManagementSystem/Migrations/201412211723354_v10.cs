namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrollCourse",
                c => new
                    {
                        EnrollCourseId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        EnrollDate = c.DateTime(nullable: false),
                        GradeName = c.String(),
                    })
                .PrimaryKey(t => t.EnrollCourseId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollCourse", "StudentId", "dbo.Student");
            DropForeignKey("dbo.EnrollCourse", "CourseId", "dbo.Course");
            DropIndex("dbo.EnrollCourse", new[] { "CourseId" });
            DropIndex("dbo.EnrollCourse", new[] { "StudentId" });
            DropTable("dbo.EnrollCourse");
        }
    }
}
