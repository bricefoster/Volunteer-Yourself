using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VolunteerOrganizer.Adapter.Interfaces;
using VolunteerOrganizer.Data;
using VolunteerOrganizer.Data.Model;
using Twilio;

namespace VolunteerOrganizer.Adapter.Adapters
{
    public class EventAdapter : IEventAdapter
    {
        public List<Event> GetEvents(int id)
        {

            List<Event> Events;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                Events = db.Events.Where(c => c.OrganizationId == id && c.IsDeleted == false).ToList();
            }
            return Events;

        }

        public Event GetMyEvent(int id)
        {
            Event myEvent;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                myEvent = db.Events.Find(id);
            }

            return myEvent;
        }
        public Event GetOrganizationId(int id)
        {
            Event myEvent;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                myEvent = db.Events.Find(id);




            }
            return myEvent;
        }

        public void EditEvent(Event myEvent)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Event model = db.Events.Find(myEvent.EventId);
                model.EventName = myEvent.EventName;
                model.About = myEvent.About;
                model.City = myEvent.City;
                model.ContactEmail = myEvent.ContactEmail;
                model.ContactNumber = myEvent.ContactNumber;
                model.ContactPerson = myEvent.ContactPerson;
                model.Country = myEvent.Country;
                model.Date = myEvent.Date;
                model.EndTime = myEvent.EndTime;
                model.Info = myEvent.Info;
                model.IsDeleted = myEvent.IsDeleted;
                model.StartTime = myEvent.StartTime;
                model.State = myEvent.State;
                model.Street = myEvent.Street;
                model.ZipCode = myEvent.ZipCode;

                db.SaveChanges();

            }
        }

        public void AddEvent(Event myEvent)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Events.Add(myEvent);
                db.SaveChanges();

            }
        }
        public void DeleteEvent(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Event myEvent = db.Events.Find(id);

                myEvent.IsDeleted = true;

                db.SaveChanges();
            }
        }

        public List<User_Event> SendMessage(int id)
        {
            string AccountSid = "AC417b3447e814ff1e9f4730b90e992b27";
            string AuthToken = "196f178520c0f6129ee735aeb4cb6451";

            TwilioRestClient client = new TwilioRestClient(AccountSid, AuthToken);

            List<User_Event> people;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                people = db.User_Events.Include("user").Include("Event").Where(x => x.EventId == id).ToList();
            }

            foreach (var person in people)
            {
                client.SendMessage("832-924-6805", person.user.ContactNumber, "The " + person.Event.EventName + " event has been canceled");
            }

            return people;


        }

       public List<User_Event> SendMessageToAll(int id, string message)
        {
            string AccountSid = "AC417b3447e814ff1e9f4730b90e992b27";
            string AuthToken = "196f178520c0f6129ee735aeb4cb6451";

            TwilioRestClient client = new TwilioRestClient(AccountSid, AuthToken);

            List<User_Event> people;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                people = db.User_Events.Include("user").Include("Event").Where(x => x.EventId == id).ToList();
            }

            foreach (var person in people)
            {
                client.SendMessage("832-924-6805", person.user.ContactNumber, message);
            }

            return people;
        }

       public List<User_Event> ConfirmMessage(int id)
       {
           List<User_Event> people;
           using (ApplicationDbContext db = new ApplicationDbContext())
           {
               people = db.User_Events.Include("user").Include("Event").Where(x => x.EventId == id).ToList();
           }

           return people;
       }
    }
}