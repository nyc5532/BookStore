namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.String());
            Sql("update dbo.Products set Quantity = 0");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
