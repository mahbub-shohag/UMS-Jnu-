namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Course", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Course", "SemesterId", "dbo.Semester");
            DropForeignKey("dbo.Student", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Teacher", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Teacher", "DesignationId", "dbo.Designation");
            CreateTable(
                "dbo.AssignCourse",
                c => new
                    {
                        AssignCourseId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CreditTaken = c.Double(nullable: false),
                        RemaingCredit = c.Double(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignCourseId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Teacher", t => t.TeacherId)
                .Index(t => t.DepartmentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            AddColumn("dbo.Course", "AssignTo", c => c.String());
            AddColumn("dbo.Teacher", "Course_CourseId", c => c.Int());
            CreateIndex("dbo.Teacher", "Course_CourseId");
            AddForeignKey("dbo.Teacher", "Course_CourseId", "dbo.Course", "CourseId");
            AddForeignKey("dbo.Course", "DepartmentId", "dbo.Department", "DepartmentId");
            AddForeignKey("dbo.Course", "SemesterId", "dbo.Semester", "SemesterId");
            AddForeignKey("dbo.Student", "DepartmentId", "dbo.Department", "DepartmentId");
            AddForeignKey("dbo.Teacher", "DepartmentId", "dbo.Department", "DepartmentId");
            AddForeignKey("dbo.Teacher", "DesignationId", "dbo.Designation", "DesignationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teacher", "DesignationId", "dbo.Designation");
            DropForeignKey("dbo.Teacher", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Student", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Course", "SemesterId", "dbo.Semester");
            DropForeignKey("dbo.Course", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.AssignCourse", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.AssignCourse", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.AssignCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Teacher", "Course_CourseId", "dbo.Course");
            DropIndex("dbo.Teacher", new[] { "Course_CourseId" });
            DropIndex("dbo.AssignCourse", new[] { "CourseId" });
            DropIndex("dbo.AssignCourse", new[] { "TeacherId" });
            DropIndex("dbo.AssignCourse", new[] { "DepartmentId" });
            DropColumn("dbo.Teacher", "Course_CourseId");
            DropColumn("dbo.Course", "AssignTo");
            DropTable("dbo.AssignCourse");
            AddForeignKey("dbo.Teacher", "DesignationId", "dbo.Designation", "DesignationId", cascadeDelete: true);
            AddForeignKey("dbo.Teacher", "DepartmentId", "dbo.Department", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Student", "DepartmentId", "dbo.Department", "DepartmentId", cascadeDelete: true);
            AddForeignKey("dbo.Course", "SemesterId", "dbo.Semester", "SemesterId", cascadeDelete: true);
            AddForeignKey("dbo.Course", "DepartmentId", "dbo.Department", "DepartmentId", cascadeDelete: true);
        }
    }
}
