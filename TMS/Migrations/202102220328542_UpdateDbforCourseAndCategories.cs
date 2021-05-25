namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbforCourseAndCategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CourseId", c => c.Int());
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Courses", "Description", c => c.String(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CourseId");
            AddForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CourseId", "dbo.Courses");
            DropIndex("dbo.AspNetUsers", new[] { "CourseId" });
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Description", c => c.String());
            DropColumn("dbo.AspNetUsers", "CourseId");
        }
    }
}
