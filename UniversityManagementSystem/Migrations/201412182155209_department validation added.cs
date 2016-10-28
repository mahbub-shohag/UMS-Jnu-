namespace UniversityManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmentvalidationadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Department", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Department", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Department", "Name", c => c.String());
            AlterColumn("dbo.Department", "Code", c => c.String());
        }
    }
}
