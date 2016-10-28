namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class depsemcoursevalidationadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Course", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Course", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Semester", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Semester", "Name", c => c.String());
            AlterColumn("dbo.Course", "Name", c => c.String());
            AlterColumn("dbo.Course", "Code", c => c.String());
        }
    }
}
