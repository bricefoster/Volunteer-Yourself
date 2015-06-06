using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolunteerOrganizer.Adapter.Adapters;
using VolunteerOrganizer.Adapter.Interfaces;
using VolunteerOrganizer.Data.Model;

namespace VolunteerOrganizer.Controllers
{
    public class EventController : Controller
    {
        IEventAdapter _adapter;
        public EventController()
        {
            _adapter = new EventAdapter();
        }
        public EventController(IEventAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET: Event
        public ActionResult EventHome(int id)
        {
            List<Event> model = _adapter.GetEvents(id);

            return View(model);

        }
        public ActionResult EventDetails(int id)
        {
            List<Event> model = _adapter.GetEvents(id);

            return View(model);

        }
        public ActionResult EditMyEvent(int id)
        {
            Event myEvent = _adapter.GetMyEvent(id);

            return View(myEvent);
        }
        [HttpPost]
        public ActionResult EditMyEvent(Event myEvent)
        {
            _adapter.EditEvent(myEvent);

            return RedirectToAction("OrganizationHome", "Organization");
        }
        public ActionResult DeleteEvent(int id)
        {
            _adapter.DeleteEvent(id);

            return RedirectToAction("OrganizationHome", "Organization");
        }
        public ActionResult ManageEvents(int id)
        {
            List<Event> model = _adapter.GetEvents(id);

            return View(model);
        }

        public ActionResult AddEvent(int id)
        {
            Event model = new Event();

            model.OrganizationId = id;


            return View(model);
        }

        [HttpPost]
        public ActionResult AddEvent(Event myEvent)
        {
            _adapter.AddEvent(myEvent);

            return RedirectToAction("OrganizationHome", "Organization");
        }

        public ActionResult SendMessage(int id)
        {
            List<User_Event> model = _adapter.SendMessage(id);

            return View (model);
           
        }
        public ActionResult SendMessageToAll(int id)
        {
            User_Event model = new User_Event();

            model.EventId = id;
           
            return View(model);
        }

        [HttpPost]
        public ActionResult SendMessageToAll(int id, string message)
        {

             _adapter.SendMessageToAll(id, message);

             User_Event model = new User_Event();
             model.EventId = id;


            return View(model);
        }

        public ActionResult ConfirmMessage(int id)
        {


            List<User_Event> model = _adapter.ConfirmMessage(id);

            return View(model);
        }
       
        
       

    }
}