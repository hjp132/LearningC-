namespace OdeToFood.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CuisineTypes", "ImageFile", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CuisineTypes", "ImageFile");
        }
    }
}
