namespace TruYum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Category Values( 'Main Course')");
            Sql("INSERT INTO Category Values( 'Starters')");
            Sql("INSERT INTO Category Values( 'Snacks')");


        }
        
        public override void Down()
        {
        }
    }
}
