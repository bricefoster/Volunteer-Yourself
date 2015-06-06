using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VolunteerOrganizer.Adapter.Adapters;
using VolunteerOrganizer.Adapter.Interfaces;
using VolunteerOrganizer.Data.Model;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace VolunteerOrganizer.Controllers
{
    [Authorize]
    public class VolunteerController : Controller
    {
        // GET: Volunteer
        IVolunteerAdapter _adapter;
        public VolunteerController()
        {
            _adapter = new VolunteerAdapter();
        }
        public VolunteerController(IVolunteerAdapter adapter)
        {
            _adapter = adapter;
        }
        public ActionResult SaveMyEvent(int id)
        {
            Event myEvent = _adapter.GetMyEvent(id);

            return View(myEvent);
        }

        [HttpPost]
        public ActionResult SaveMyEvent(Event myEvent)
        {
            
            string id = User.Identity.GetUserId();

            _adapter.SaveEvent(myEvent, id);

            return RedirectToAction("GetUserEvents", "Volunteer");
        }
        public ActionResult GetUserEvents()
        {
            string id = User.Identity.GetUserId();

            List<User_Event> model = _adapter.GetUserEvents(id);

            return View(model);

        }


    }
}