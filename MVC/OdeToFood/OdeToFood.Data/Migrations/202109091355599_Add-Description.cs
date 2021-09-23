namespace OdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Desc", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Desc");
        }
    }
}
