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
    public class HomeController : Controller
    {
        IOrganizationAdapter _adapter;
        public HomeController()
        {
            _adapter = new OrganizationAdapter();
        }
        public HomeController(IOrganizationAdapter adapter)
        {
            _adapter = adapter;
        }
        public ActionResult Index()
        {
            List<Organization> model = _adapter.GetAllOrganizations();

            return View(model);
        }

        public ActionResult VolunteerHome()
        {
            List<Organization> model = _adapter.GetAllOrganizations();

            return View(model);
        }
      
       

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}