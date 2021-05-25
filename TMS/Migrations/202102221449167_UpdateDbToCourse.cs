namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDbToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UsersId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UsersId");
        }
    }
}
