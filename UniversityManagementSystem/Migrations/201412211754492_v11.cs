namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.ResultEntry",
                c => new
                    {
                        ResultEntryId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResultEntryId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Grade", t => t.GradeId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultEntry", "StudentId", "dbo.Student");
            DropForeignKey("dbo.ResultEntry", "GradeId", "dbo.Grade");
            DropForeignKey("dbo.ResultEntry", "CourseId", "dbo.Course");
            DropIndex("dbo.ResultEntry", new[] { "GradeId" });
            DropIndex("dbo.ResultEntry", new[] { "CourseId" });
            DropIndex("dbo.ResultEntry", new[] { "StudentId" });
            DropTable("dbo.ResultEntry");
            DropTable("dbo.Grade");
        }
    }
}
