using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackCountryFreedom.Core.Contracts;
using BackCountryFreedom.Core.ViewModels;
using BackCountryFreedom.Core.Models;


namespace BackCountryFreedom.WebUI.Controllers
{
    public class TrailController : Controller
    {
        IRepository<Trail> context;
        IRepository<Difficulty> difficulty;
        IRepository<DistanceScale> distanceScale;
        IRepository<ElevationScale> elevationScale;
        IRepository<Location> location;
        IRepository<ActivityType> actvitytype;

        public TrailController(IRepository<Trail> trailcontext, IRepository<Difficulty> difficultycontext, IRepository<DistanceScale> distanceScalecontext,
           IRepository<ElevationScale> elevationScalecontext, IRepository<Location> locationcontext, IRepository<ActivityType> activityTypecontext)
        {
            context = trailcontext;
            difficulty = difficultycontext;
            distanceScale = distanceScalecontext;
            elevationScale = elevationScalecontext;
            location = locationcontext;
            actvitytype = activityTypecontext;
        }

        // GET: TrailManager
        public ActionResult Index()
        {
            List<Trail> trails = context.Collection().ToList();
            return View(trails);
        }

        public ActionResult Create()
        {
            TrailManagerViewModel viewModel = new TrailManagerViewModel();

            viewModel.Trail = new Trail();
            viewModel.Difficulties = difficulty.Collection();
            viewModel.DistanceScales = distanceScale.Collection();
            viewModel.ElevationScales = elevationScale.Collection();
            viewModel.Locations = location.Collection();
            viewModel.ActivityTypes = actvitytype.Collection();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Trail trail,HttpPostedFileBase file)
        {
            if(!ModelState.IsValid)
            {
                return View(trail);
            }
            else
            {
                if(file!=null)
                {
                    trail.Image = trail.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//pics//") + trail.Image);

                }
                context.Insert(trail);
                context.Commit();

                return RedirectToAction("Indext");
            }
        }

        public ActionResult Edit(string Id)
        {
            Trail trail = context.Find(Id);
            if (trail == null)
            {
                return HttpNotFound();
            }
            else
            {
                TrailManagerViewModel viewModel = new TrailManagerViewModel();

                viewModel.Trail = new Trail();
                viewModel.Difficulties = difficulty.Collection();
                viewModel.DistanceScales = distanceScale.Collection();
                viewModel.ElevationScales = elevationScale.Collection();
                viewModel.Locations = location.Collection();
                viewModel.ActivityTypes = actvitytype.Collection();

                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(Trail trail, string Id, HttpPostedFileBase file)
        {
            Trail trailToEdit = context.Find(Id);
            if(trail == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(trail);
                }
                if(file!=null)
                {
                    trailToEdit.Image = trail.Id + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//pics//") + trailToEdit.Image);
                }
                trailToEdit.Name = trail.Name;
                trailToEdit.Description = trail.Description;
                trailToEdit.Long = trail.Long;
                trailToEdit.Lat = trail.Lat;
                trailToEdit.Distance = trail.Distance;
                trailToEdit.Difficulty = trail.Difficulty;
                trailToEdit.Location = trail.Location;

                context.Commit();

                return RedirectToAction("Index");
             }
        }
        public ActionResult Delete(string Id)
        {
            Trail trailToDelete = context.Find(Id);
            if (trailToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(trailToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Trail trailToDelete = context.Find(Id);
            if (trailToDelete == null)
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