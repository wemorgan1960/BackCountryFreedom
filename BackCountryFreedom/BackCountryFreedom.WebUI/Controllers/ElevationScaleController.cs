using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackCountryFreedom.Core.Contracts;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.WebUI.Controllers
{
    public class ElevationScaleController : Controller
    {
        IRepository<ElevationScale> context;

        public ElevationScaleController(IRepository<ElevationScale> actvitytypecontext)
        {
            context = actvitytypecontext;
        }

        // GET: TrailManager
        public ActionResult Index()
        {
            List<ElevationScale> elevationScale = context.Collection().ToList();
            return View(elevationScale);
        }

        public ActionResult Create()
        {
            ElevationScale view = new ElevationScale();

            return View(view);
        }

        [HttpPost]
        public ActionResult Create(ElevationScale elevationScale)
        {
            if (!ModelState.IsValid)
            {
                return View(elevationScale);
            }
            else
            {
                context.Insert(elevationScale);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ElevationScale elevationScale = context.Find(Id);
            if (elevationScale == null)
            {
                return HttpNotFound();
            }
            else
            {
                ElevationScale view = new ElevationScale();

                return View(view);
            }
        }
        [HttpPost]
        public ActionResult Edit(ElevationScale elevation, string Id)
        {
            ElevationScale elevationToEdit = context.Find(Id);
            if (elevation == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(elevation);
                }
                elevationToEdit.Description = elevation.Description;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            ElevationScale elevationToDelete = context.Find(Id);
            if (elevationToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(elevationToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ElevationScale elevationToDelete = context.Find(Id);
            if (elevationToDelete == null)
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