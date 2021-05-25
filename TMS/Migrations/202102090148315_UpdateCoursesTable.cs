namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateCoursesTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "CatId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "CatId", c => c.Int(nullable: false));
        }
    }
}
