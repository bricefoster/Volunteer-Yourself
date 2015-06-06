using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolunteerOrganizer.Adapter.Interfaces;
using VolunteerOrganizer.Data;
using VolunteerOrganizer.Data.Model;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;


namespace VolunteerOrganizer.Adapter.Adapters
{
    public class VolunteerAdapter : IVolunteerAdapter
    {
        public Event GetMyEvent(int id)
        {
            Event myEvent;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                myEvent = db.Events.Find(id);
                
            }

            return myEvent;
        }
        public void SaveEvent(Event myEvent, string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                User_Event model = new User_Event();
              
                model.EventId = myEvent.EventId;
                model.ApplicationUserId = id;

                db.User_Events.Add(model);

                db.SaveChanges();

            }
        }

        public List<User_Event> GetUserEvents(string id)
        {
            List<User_Event> Events;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                Events = db.User_Events.Include("Event").Where(c => c.ApplicationUserId == id && c.Event.IsDeleted == false).ToList();
            }
            return Events;
        }

        
    }
}