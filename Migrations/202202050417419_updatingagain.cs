namespace TruYum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItem", "DateOfLaunch", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItem", "DateOfLaunch");
        }
    }
}
