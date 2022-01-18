namespace WebAppAspNetMvcCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DayOfWeeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeekName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PerformerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Performers", t => t.PerformerId, cascadeDelete: true)
                .Index(t => t.PerformerId);
            
            CreateTable(
                "dbo.Performers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PerformerImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        Data = c.Binary(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        DateChanged = c.DateTime(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Performers", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.TaskDayOfWeeks",
                c => new
                    {
                        Task_Id = c.Int(nullable: false),
                        DayOfWeek_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_Id, t.DayOfWeek_Id })
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .ForeignKey("dbo.DayOfWeeks", t => t.DayOfWeek_Id, cascadeDelete: true)
                .Index(t => t.Task_Id)
                .Index(t => t.DayOfWeek_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "PerformerId", "dbo.Performers");
            DropForeignKey("dbo.PerformerImages", "Id", "dbo.Performers");
            DropForeignKey("dbo.TaskDayOfWeeks", "DayOfWeek_Id", "dbo.DayOfWeeks");
            DropForeignKey("dbo.TaskDayOfWeeks", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.TaskDayOfWeeks", new[] { "DayOfWeek_Id" });
            DropIndex("dbo.TaskDayOfWeeks", new[] { "Task_Id" });
            DropIndex("dbo.PerformerImages", new[] { "Id" });
            DropIndex("dbo.Tasks", new[] { "PerformerId" });
            DropTable("dbo.TaskDayOfWeeks");
            DropTable("dbo.PerformerImages");
            DropTable("dbo.Performers");
            DropTable("dbo.Tasks");
            DropTable("dbo.DayOfWeeks");
        }
    }
}
