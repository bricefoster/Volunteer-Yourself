using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteerOrganizer.Data.Model;
using System.Data.Entity.Migrations;

namespace VolunteerOrganizer.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db, bool roles = false, bool users = false, bool organizations = false, bool events = false, bool userEvents = false)
        {
            if (roles) SeedRoles(db);
            if (users) SeedUsers(db);
            if (organizations) SeedOrganizations(db);
            if (events) SeedEvents(db);
            if (userEvents) SeedUserEvents(db);

        }
        private static void SeedRoles(ApplicationDbContext db)
        {
            var store = new RoleStore<IdentityRole>(db);
            var manager = new RoleManager<IdentityRole>(store);

            if (!db.Roles.Any(x => x.Name == "Admin"))
            {
                manager.Create(new IdentityRole() { Name = "Admin" });
            }

            if (!db.Roles.Any(x => x.Name == "User"))
            {
                manager.Create(new IdentityRole() { Name = "User" });
            }

        }
        private static void SeedUsers(ApplicationDbContext db)
        {
            var store = new UserStore<ApplicationUser>(db);
            var manager = new UserManager<ApplicationUser>(store);

            if (!db.Users.Any(x => x.Email == "sky@email.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "sky@email.com",
                    Email = "sky@email.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "User");
            }
            if (!db.Users.Any(x => x.Email == "brice@email.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "brice@email.com",
                    Email = "brice@email.com"

                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "Admin");
            }
            if (!db.Users.Any(x => x.Email == "cherish@email.com"))
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = "cherish@email.com",
                    Email = "cherish@email.com"
                };
                manager.Create(user, "123123");
                manager.AddToRole(user.Id, "User");
            }
            db.SaveChanges();
        }
        private static void SeedOrganizations(ApplicationDbContext db)
        {
            db.Organizations.AddOrUpdate(x => x.OrganizationName,
                new Organization()
                {
                    OrganizationName = "Feed Hunger",
                    OrganizationPicture = "http://images.cdn.bigcartel.com/bigcartel/theme_images/668721/max_h-1000+max_w-1000/Untitled-1.jpg",
                    OrganizationAbout = "We feed hungry children in the Houston Area."
                   
                },
                new Organization()
                {
                    OrganizationName = "Coding Kids",
                    OrganizationPicture = "http://airskull.com/wp-content/uploads/2014/02/kidsthatcodelarge.png",
                    OrganizationAbout = "Helping kids learn to Code."
                   
                },
                new Organization()
                {
                    OrganizationName = "Soldiers are Us",
                    OrganizationPicture = "http://archive.wtsp.com/assetpool/images/110215042559_soldier%20ride%20web%202.jpg",
                    OrganizationAbout = "Giving soldier a shoulder to lean on when they get back home",
                    
                });
            db.SaveChanges();
        }
        private static void SeedEvents(ApplicationDbContext db)
        {
            db.Events.AddOrUpdate(x => x.EventName,
                new Event()
                {
                    EventName = "Kicking Hunger Out",
                    About = "Hosting a soccer game to raise money",
                    Date = "02/20/2015",
                    StartTime = "1:00pm",
                    EndTime = "6:00pm",
                    Street = "8540 Hampton St.",
                    City = "Sugar Land",
                    State = "TX",
                    ZipCode = 77478,
                    Country = "US",
                    ContactEmail = "mike@email.com",
                    ContactPerson = "Mike",
                    ContactNumber = "444-444-4444",
                    Info = "Email mike if you have to cannot make it on the day of event",
                    IsDeleted = false,
                    OrganizationId = 1
                },

                new Event()
                {
                    EventName = "Teaching Kids HTML",
                    About = "Teaching kids HTML at Glen Elementry School",
                    Date = "05/13/2015",
                    StartTime = "3:30pm",
                    EndTime = "5:00pm",
                    Street = "3456 North Glen",
                    City = "Houston",
                    State = "TX",
                    ZipCode = 70057,
                    Country = "US",
                    ContactEmail = "rob@email.com",
                    ContactPerson = "Rob",
                    ContactNumber = "555-555-5555",
                    Info = "The room will be 500",
                    IsDeleted = false,
                    OrganizationId = 2
                },

                new Event()
                {
                    EventName = "Fishing with the Soldiers",
                    About = "We are taking the soldiers out to fish in Galveston",
                    Date = "05/16/2015",
                    StartTime = "7:00am",
                    EndTime = "11:00pm",
                    Street = "Old South Road",
                    City = "Galveston",
                    State = "TX",
                    ZipCode = 88498,
                    Country = "US",
                    ContactEmail = "maria@email.com",
                    ContactPerson = "Maria",
                    ContactNumber = "777-777-7777",
                    Info = "A bus will be leaving from base at 6:00am sharp",
                    IsDeleted = false,
                    OrganizationId = 3
                });
            db.SaveChanges();
        }

        public static void SeedUserEvents(ApplicationDbContext db)
        {
            db.User_Events.AddOrUpdate(x => x.User_EventId,
                new User_Event() { EventId = 1, ApplicationUserId = "2642d590-cc9e-44f3-adfb-b854c156ec40" },
                new User_Event() { EventId = 2, ApplicationUserId = "54bd49a6-8f08-42a2-8864-b7954018ad17" },
                new User_Event() { EventId = 3, ApplicationUserId = "766ad1d9-c572-4b98-a4d6-12e57abb6c01" });
            db.SaveChanges();
        }

        
    }
}
