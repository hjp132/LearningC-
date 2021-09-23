namespace OdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRestaurantImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        ImagePath = c.String(nullable: false),
                        ImageFile = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RestaurantImages");
        }
    }
}
