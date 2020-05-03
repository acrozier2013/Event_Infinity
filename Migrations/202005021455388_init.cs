namespace Event_Infinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        EventId = c.Int(nullable: false),
                        CountofTickets = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            AlterColumn("dbo.Events", "EventTitle", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Events", "EventDescription", c => c.String(maxLength: 150));
            AlterColumn("dbo.Events", "EventLocation", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EventId", "dbo.Events");
            DropIndex("dbo.Orders", new[] { "EventId" });
            AlterColumn("dbo.Events", "EventLocation", c => c.String());
            AlterColumn("dbo.Events", "EventDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EventTitle", c => c.String(nullable: false));
            DropTable("dbo.Orders");
        }
    }
}
