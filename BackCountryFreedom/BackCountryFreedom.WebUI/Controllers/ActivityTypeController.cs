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
    public class ActivityTypeController : Controller
    {
        IRepository<ActivityType> context;

        public ActivityTypeController()
        {
            context = new InMemoryRepository<ActivityType>();
        }

        // GET: TrailManager
        public ActionResult Index()
        {
            List<ActivityType> activityTypes = context.Collection().ToList();
            return View(activityTypes);
        }

        public ActionResult Create()
        {
            ActivityType view = new ActivityType();

            return View(view);
        }

        [HttpPost]
        public ActionResult Create(ActivityType activityType)
        {
            if (!ModelState.IsValid)
            {
                return View(activityType);
            }
            else
            {
                context.Insert(activityType);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ActivityType activityType = context.Find(Id);
            if (activityType == null)
            {
                return HttpNotFound();
            }
            else
            {
                ActivityType view = new ActivityType();

                return View(view);
            }
        }
        [HttpPost]
        public ActionResult Edit(ActivityType activtyType, string Id)
        {
            ActivityType activityTypeToEdit = context.Find(Id);
            if (activtyType == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(activtyType);
                }
                activityTypeToEdit.Description = activtyType.Description;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            ActivityType activityTypeToEdit = context.Find(Id);
            if (activityTypeToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(activityTypeToEdit);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ActivityType activityTypeToDelete = context.Find(Id);
            if (activityTypeToDelete == null)
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
