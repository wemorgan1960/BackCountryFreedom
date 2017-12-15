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
    public class DifficultyController : Controller
    {
        IRepository<Difficulty> context;

        public DifficultyController(IRepository<Difficulty> context)
        {
            this.context = context;
        }

        // GET: TrailManager
        public ActionResult Index()
        {
            List<Difficulty> difficulty = context.Collection().ToList();
            return View(difficulty);
        }

        public ActionResult Create()
        {
            Difficulty view = new Difficulty();

            return View(view);
        }

        [HttpPost]
        public ActionResult Create(Difficulty difficulty)
        {
            if (!ModelState.IsValid)
            {
                return View(difficulty);
            }
            else
            {
                context.Insert(difficulty);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Difficulty difficulty = context.Find(Id);
            if (difficulty == null)
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
        public ActionResult Edit(Difficulty difficutly, string Id)
        {
            Difficulty difficultyToEdit = context.Find(Id);
            if (difficultyToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(difficultyToEdit);
                }
                difficultyToEdit.Description = difficultyToEdit.Description;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Difficulty difficultyToEdit = context.Find(Id);
            if (difficultyToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(difficultyToEdit);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Difficulty difficultyToDelete = context.Find(Id);
            if (difficultyToDelete == null)
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