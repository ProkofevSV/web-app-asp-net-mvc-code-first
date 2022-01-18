namespace WebAppAspNetMvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vers2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Description");
        }
    }
}
