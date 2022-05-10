namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Slides", "Description", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Slides", "Description", c => c.String(nullable: false, maxLength: 256));
        }
    }
}
