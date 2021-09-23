namespace OdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _345235 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RestaurantImages", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RestaurantImages", "ImagePath", c => c.String(nullable: false));
        }
    }
}
