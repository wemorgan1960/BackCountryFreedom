using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackCountryFreedom.Core.Contracts;
using BackCountryFreedom.Core.ViewModels;
using BackCountryFreedom.Core.Models;

namespace BackCountryFreedom.WebUI.Controllers
{
    public class ObservationController : Controller
    {
        IRepository<Observation> context;
        IRepository<Season> season;
        IRepository<DistanceScale> distanceScale;
        IRepository<ElevationScale> elevationScale;

        public ObservationController(IRepository<Observation> observationcontext, IRepository<Season> seasonContext
            , IRepository<DistanceScale> distanceScaleContext, IRepository<ElevationScale> elevationScaleContext)
        {
            context = observationcontext;
            season = seasonContext;
            distanceScale = distanceScaleContext;
            elevationScale = elevationScaleContext;
        }

        // GET: TrailManager
        public ActionResult Index()
        {
            List<Observation> observation = context.Collection().ToList();
            return View(observation);
        }

        public ActionResult Create()
        {
            ObservationManagerViewModel viewModel = new ObservationManagerViewModel();

            viewModel.Observation = new Observation();
            viewModel.Seasons = season.Collection();
            viewModel.DistanceScales = distanceScale.Collection();
            viewModel.ElevationScales = elevationScale.Collection();
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Observation observation)
        {
            if (!ModelState.IsValid)
            {
                return View(observation);
            }
            else
            {
                context.Insert(observation);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Observation observation = context.Find(Id);
            if (observation == null)
            {
                return HttpNotFound();
            }
            else
            {
                ObservationManagerViewModel viewModel = new ObservationManagerViewModel();
                viewModel.Observation = observation;
                viewModel.Seasons = season.Collection();
                viewModel.DistanceScales = distanceScale.Collection();
                viewModel.ElevationScales = elevationScale.Collection();

                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(Observation observation, string Id)
        {
            Observation observationToEdit = context.Find(Id);
            if (observation == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(observation);
                }
                observationToEdit.Date = observation.Date;
                observationToEdit.User = observation.User;
                observationToEdit.Name = observation.Name;
                observationToEdit.Description = observation.Description;
                observationToEdit.Distance = observation.Distance;
                observationToEdit.DistanceScale = observationToEdit.DistanceScale;
                observationToEdit.Elevation = observation.Elevation;
                observationToEdit.ElevationScale = observation.ElevationScale;
                observationToEdit.ActivityType = observation.ActivityType;
                observationToEdit.Season = observation.Season;
                observationToEdit.Hazards = observation.Hazards;
                observationToEdit.WeatherConditions = observation.WeatherConditions;
                observationToEdit.Rating = observation.Rating;
                
                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Observation observationTypeToEdit = context.Find(Id);
            if (observationTypeToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(observationTypeToEdit);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Observation observationToDelete = context.Find(Id);
            if (observationToDelete == null)
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