namespace Event_Infinity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnwantedColumnCleanup : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Events", "EventDescription", c => c.String(nullable: false));
            //AlterColumn("dbo.Events", "EventTitle", c => c.String(nullable: false));
            //AlterColumn("dbo.Events", "OrganizerName", c => c.String(nullable: false));
            //AlterColumn("dbo.EventTypes", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Events", "EventStartTime");
            DropColumn("dbo.Events", "EventEndTime");
        }
        
        //public override void Down()
        //{
        //    AddColumn("dbo.Events", "EventEndTime", c => c.DateTime(nullable: false));
        //    AddColumn("dbo.Events", "EventStartTime", c => c.DateTime(nullable: false));
        //    AlterColumn("dbo.EventTypes", "Description", c => c.String());
        //    AlterColumn("dbo.Events", "OrganizerName", c => c.String());
        //    AlterColumn("dbo.Events", "EventTitle", c => c.String());
        //    DropColumn("dbo.Events", "EventDescription");
        //}
    }
}
