using BackCountryFreedom.Core.Contracts;
using BackCountryFreedom.Core.Models;
using BackCountryFreedom.Core.ViewModels;
using BackCountryFreedom.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackCountryFreedom.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Trail> context;
        IRepository<Difficulty> difficulty;
        IRepository<DistanceScale> distanceScale;
        IRepository<ElevationScale> elevationScale;
        IRepository<Location> location;
        IRepository<ActivityType> actvitytype;

        public HomeController()
        {
            context = new InMemoryRepository<Trail>();
            difficulty = new InMemoryRepository<Difficulty>();
            distanceScale = new InMemoryRepository<DistanceScale>();
            elevationScale = new InMemoryRepository<ElevationScale>();
            location = new InMemoryRepository<Location>();
            actvitytype = new InMemoryRepository<ActivityType>();
        }
        public ActionResult Index(string Location = null)
        {
            List<Trail> trails;
            List<Location> locations = location.Collection().ToList();

            if (Location ==null)
            {
                trails = context.Collection().ToList();
            }
            else
            {
                trails = context.Collection().Where(t => t.Location == Location).ToList();
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