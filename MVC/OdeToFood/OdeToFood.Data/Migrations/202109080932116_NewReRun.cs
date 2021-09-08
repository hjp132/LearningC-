namespace OdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewReRun : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CuisineTypes", "ImagePath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CuisineTypes", "ImagePath", c => c.String());
        }
    }
}
