namespace VolunteerOrganizer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditEventUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "user_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "user_Id" });
            DropColumn("dbo.Events", "user_Id");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "ContactNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ContactNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.Events", "user_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "user_Id");
            AddForeignKey("dbo.Events", "user_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
