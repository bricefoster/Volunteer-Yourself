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
    public class OrganizationController : Controller
    {
        IOrganizationAdapter _adapter;
        public OrganizationController()
        {
            _adapter = new OrganizationAdapter();
        }
        public OrganizationController(IOrganizationAdapter adapter)
        {
            _adapter = adapter;
        }
        // GET: Organization
        public ActionResult OrganizationHome()
        {
            string id = User.Identity.GetUserId();

            List<Organization> model = _adapter.GetOrganizations(id);

            return View(model);
        }

        public ActionResult EditMyOrganization(int id)
        {
            Organization model = _adapter.GetMyOrganization(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditMyOrganization(Organization organization)
        {
            string id = User.Identity.GetUserId();
            _adapter.EditOrganization(id, organization);

            return RedirectToAction("OrganizationHome");
        
        }
        public ActionResult GetVolunteers(int id)
        {
            List<User_Event> model = _adapter.GetVolunteers(id);

            return View(model);
        }
       


    }
}