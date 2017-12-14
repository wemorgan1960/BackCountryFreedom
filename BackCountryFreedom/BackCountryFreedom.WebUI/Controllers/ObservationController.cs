using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackCountryFreedom.Core.Contracts;
using BackCountryFreedom.Models;

namespace BackCountryFreedom.WebUI.Controllers
{
    public class ObservationController : Controller
    {
        IRepository<Observation> context;

        public ObservationController(IRepository<Observation> observationcontext)
        {
            context = observationcontext;
        }

        // GET: TrailManager
        public ActionResult Index()
        {
            List<Observation> observation = context.Collection().ToList();
            return View(observation);
        }

        public ActionResult Create()
        {
            Observation view = new Observation();

            return View(view);
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
                Observation view = new Observation();

                return View(view);
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
                observationToEdit.Elevation = observation.Elevation;
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