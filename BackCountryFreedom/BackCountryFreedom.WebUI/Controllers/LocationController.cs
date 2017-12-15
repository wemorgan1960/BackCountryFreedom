using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackCountryFreedom.Core.Contracts;
using BackCountryFreedom.Core.Models;
using BackCountryFreedom.DataAccess.InMemory;

namespace BackCountryFreedom.WebUI.Controllers
{
    public class LocationController : Controller
    {
        IRepository<Location> context;

        public LocationController()
        {
            context = new InMemoryRepository<Location>();
        }

        // GET: TrailManager
        public ActionResult Index()
        {
            List<Location> locations = context.Collection().ToList();
            return View(locations);
        }

        public ActionResult Create()
        {
            Location view = new Location();

            return View(view);
        }

        [HttpPost]
        public ActionResult Create(Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }
            else
            {
                context.Insert(location);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Location location = context.Find(Id);
            if (location == null)
            {
                return HttpNotFound();
            }
            else
            {
                Location view = new Location();

                return View(view);
            }
        }
        [HttpPost]
        public ActionResult Edit(Location location, string Id)
        {
            Location locationToEdit = context.Find(Id);
            if (location == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(location);
                }
                locationToEdit.Description = location.Description;
                locationToEdit.Province = location.Province;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Location locationToEdit = context.Find(Id);
            if (locationToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(locationToEdit);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Location locationToDelete = context.Find(Id);
            if (locationToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}