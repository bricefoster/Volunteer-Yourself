namespace VolunteerOrganizer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "user_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "user_Id");
            AddForeignKey("dbo.Events", "user_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "user_Id" });
            DropColumn("dbo.Events", "user_Id");
        }
    }
}
