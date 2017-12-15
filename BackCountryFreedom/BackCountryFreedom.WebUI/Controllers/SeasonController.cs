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
    public class SeasonController : Controller
    {
        IRepository<Season> context;

        public SeasonController(IRepository<Season> context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            List<Season> seasons = context.Collection().ToList();
            return View(seasons);
        }

        public ActionResult Create()
        {
            Season view = new Season();

            return View(view);
        }

        [HttpPost]
        public ActionResult Create(Season season)
        {
            if (!ModelState.IsValid)
            {
                return View(season);
            }
            else
            {
                context.Insert(season);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Season season = context.Find(Id);
            if (season == null)
            {
                return HttpNotFound();
            }
            else
            {
                Season view = new Season();

                return View(view);
            }
        }
        [HttpPost]
        public ActionResult Edit(Season season, string Id)
        {
            Season seasonToEdit = context.Find(Id);
            if (season == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(season);
                }
                seasonToEdit.Description = season.Description;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Season seasonToEdit = context.Find(Id);
            if (seasonToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(seasonToEdit);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Season seasonToDelete = context.Find(Id);
            if (seasonToDelete == null)
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