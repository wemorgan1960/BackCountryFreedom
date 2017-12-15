using BackCountryFreedom.Core.Contracts;
using BackCountryFreedom.Core.Models;
using BackCountryFreedom.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackCountryFreedom.WebUI.Controllers
{
    public class CountryController : Controller
    {
        IRepository<Country> context;

        public CountryController()
        {
            context = new InMemoryRepository<Country>();
        }

        // GET: TrailManager
        public ActionResult Index()
        {
            List<Country> country = context.Collection().ToList();
            return View(country);
        }

        public ActionResult Create()
        {
            Country view = new Country();

            return View(view);
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            if (!ModelState.IsValid)
            {
                return View(country);
            }
            else
            {
                context.Insert(country);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Country country = context.Find(Id);
            if (country == null)
            {
                return HttpNotFound();
            }
            else
            {
                Country view = new Country();

                return View(view);
            }
        }
        [HttpPost]
        public ActionResult Edit(Country country, string Id)
        {
            Country countryToEdit = context.Find(Id);
            if (country == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(country);
                }
                countryToEdit.Description = country.Description;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Country countryToEdit = context.Find(Id);
            if (countryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(countryToEdit);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Country countryToDelete = context.Find(Id);
            if (countryToDelete == null)
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