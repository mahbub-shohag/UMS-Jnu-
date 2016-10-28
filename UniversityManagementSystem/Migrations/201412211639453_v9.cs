namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teacher", "Course_CourseId", "dbo.Course");
            DropIndex("dbo.Teacher", new[] { "Course_CourseId" });
            CreateTable(
                "dbo.RoomAllocation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Day", t => t.DayId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Room", t => t.RoomId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.DayId);
            
            CreateTable(
                "dbo.Day",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DayId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoomId);
            
            CreateTable(
                "dbo.TeacherCourse",
                c => new
                    {
                        Teacher_TeacherId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_TeacherId, t.Course_CourseId })
                .ForeignKey("dbo.Teacher", t => t.Teacher_TeacherId)
                .ForeignKey("dbo.Course", t => t.Course_CourseId)
                .Index(t => t.Teacher_TeacherId)
                .Index(t => t.Course_CourseId);
            
            AddColumn("dbo.Teacher", "Address", c => c.String());
            DropColumn("dbo.Teacher", "Course_CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teacher", "Course_CourseId", c => c.Int());
            DropForeignKey("dbo.RoomAllocation", "RoomId", "dbo.Room");
            DropForeignKey("dbo.RoomAllocation", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.RoomAllocation", "DayId", "dbo.Day");
            DropForeignKey("dbo.RoomAllocation", "CourseId", "dbo.Course");
            DropForeignKey("dbo.TeacherCourse", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.TeacherCourse", "Teacher_TeacherId", "dbo.Teacher");
            DropIndex("dbo.TeacherCourse", new[] { "Course_CourseId" });
            DropIndex("dbo.TeacherCourse", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.RoomAllocation", new[] { "DayId" });
            DropIndex("dbo.RoomAllocation", new[] { "RoomId" });
            DropIndex("dbo.RoomAllocation", new[] { "CourseId" });
            DropIndex("dbo.RoomAllocation", new[] { "DepartmentId" });
            DropColumn("dbo.Teacher", "Address");
            DropTable("dbo.TeacherCourse");
            DropTable("dbo.Room");
            DropTable("dbo.Day");
            DropTable("dbo.RoomAllocation");
            CreateIndex("dbo.Teacher", "Course_CourseId");
            AddForeignKey("dbo.Teacher", "Course_CourseId", "dbo.Course", "CourseId");
        }
    }
}
