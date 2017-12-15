using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BackCountryFreedom.Core.Contracts;
using BackCountryFreedom.Core.Models;
using BackCountryFreedom.Core.ViewModels;
using BackCountryFreedom.DataAccess.InMemory;

namespace BackCountryFreedom.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Trail> context;
        IRepository<Location> location;

        public HomeController(IRepository<Trail> context, IRepository<Location> locationContext)
        {
            this.context = context;
            location = locationContext;

        }
        public ActionResult Index(string fLocation = null)
        {
            List<Trail> trails;
            List<Location> locations = location.Collection().ToList();


            if (fLocation ==null)
            {
                trails = context.Collection().ToList();
            }
            else
            {
                trails = context.Collection().Where(t => t.Location == fLocation).ToList();
            }

            TrailListViewModel model = new TrailListViewModel();
            model.Trails = trails;
            model.Locations = locations;

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