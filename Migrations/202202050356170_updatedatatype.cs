namespace TruYum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatatype : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MenuItem", "DateOfLaunch");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuItem", "DateOfLaunch", c => c.DateTime(nullable: false));
        }
    }
}
