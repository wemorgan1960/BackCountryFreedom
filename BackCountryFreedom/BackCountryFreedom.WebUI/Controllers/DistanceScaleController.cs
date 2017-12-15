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
    public class DistanceScaleController : Controller
    {
        IRepository<DistanceScale> context;

        public DistanceScaleController()
        {
            context = new InMemoryRepository<DistanceScale>();
        }

        // GET: TrailManager
        public ActionResult Index()
        {
            List<DistanceScale> DistanceScales = context.Collection().ToList();
            return View(DistanceScales);
        }

        public ActionResult Create()
        {
            DistanceScale view = new DistanceScale();

            return View(view);
        }

        [HttpPost]
        public ActionResult Create(DistanceScale DistanceScale)
        {
            if (!ModelState.IsValid)
            {
                return View(DistanceScale);
            }
            else
            {
                context.Insert(DistanceScale);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            DistanceScale DistanceScale = context.Find(Id);
            if (DistanceScale == null)
            {
                return HttpNotFound();
            }
            else
            {
                DistanceScale view = new DistanceScale();

                return View(view);
            }
        }
        [HttpPost]
        public ActionResult Edit(DistanceScale distanceScale, string Id)
        {
            DistanceScale DistanceScaleToEdit = context.Find(Id);
            if (distanceScale == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(distanceScale);
                }
                DistanceScaleToEdit.Description = distanceScale.Description;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            DistanceScale DistanceScaleToDelete = context.Find(Id);
            if (DistanceScaleToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(DistanceScaleToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            DistanceScale DistanceScaleToDelete = context.Find(Id);
            if (DistanceScaleToDelete == null)
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