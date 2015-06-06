using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolunteerOrganizer.Adapter.Interfaces;
using VolunteerOrganizer.Data;
using VolunteerOrganizer.Data.Model;

namespace VolunteerOrganizer.Adapter.Adapters
{
    public class OrganizationAdapter : IOrganizationAdapter
    {
        public List<Organization> GetAllOrganizations()
        {
            List<Organization> organizations;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                organizations = db.Organizations.ToList();
            }
            return organizations;
        }
        
        public List<Organization> GetOrganizations(string id)
        {

            List<Organization> Organizations;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {


            Organizations = db.Organizations.Where(x => x.ApplicationUserId == id).ToList();
            
            }
            return Organizations;
        }

        public Organization GetMyOrganization(int id)
        {
            Organization organization;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                organization = db.Organizations.Find(id);
            }

            return organization;
        }
        public void EditOrganization(string id, Organization organization)
        {
           using (ApplicationDbContext db = new ApplicationDbContext())
           {
               Organization model = db.Organizations.Find(organization.OrganizationId);
               model.OrganizationName = organization.OrganizationName;
               model.OrganizationAbout = organization.OrganizationAbout;
               model.OrganizationPicture = organization.OrganizationPicture;

               db.SaveChanges();
           }

        }
        public List<User_Event> GetVolunteers(int id)
        {
            List<User_Event> volunteers;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                volunteers = db.User_Events.Include("user").Include("Event").Where(x => x.Event.OrganizationId == id && x.Event.IsDeleted == false).ToList();
            }

            return volunteers;
        }

    }
}