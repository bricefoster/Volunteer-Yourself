namespace VolunteerOrganizer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account_Controller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "TypeOfUser", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "TypeOfUser");
        }
    }
}
