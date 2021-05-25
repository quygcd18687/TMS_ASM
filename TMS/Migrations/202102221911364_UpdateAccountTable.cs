namespace TMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccountTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UsersId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UsersId", c => c.Int());
        }
    }
}
