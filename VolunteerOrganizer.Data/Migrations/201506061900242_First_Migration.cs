namespace VolunteerOrganizer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(),
                        About = c.String(),
                        Date = c.String(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Country = c.String(),
                        ContactPerson = c.String(),
                        ContactNumber = c.String(),
                        ContactEmail = c.String(),
                        Info = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.user_Id)
                .Index(t => t.OrganizationId)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false, identity: true),
                        OrganizationName = c.String(),
                        OrganizationPicture = c.String(),
                        OrganizationAbout = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrganizationId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ContactNumber = c.String(),
                        TypeOfUser = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.User_Event",
                c => new
                    {
                        User_EventId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_EventId)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Event", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.User_Event", "EventId", "dbo.Events");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Events", "user_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Organizations", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Events", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.User_Event", new[] { "EventId" });
            DropIndex("dbo.User_Event", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Organizations", new[] { "ApplicationUserId" });
            DropIndex("dbo.Events", new[] { "user_Id" });
            DropIndex("dbo.Events", new[] { "OrganizationId" });
            DropTable("dbo.User_Event");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Organizations");
            DropTable("dbo.Events");
        }
    }
}
