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
    public class ProvinceController : Controller
    {
        IRepository<Province> context;

        public ProvinceController(IRepository<Province> context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            List<Province> province = context.Collection().ToList();
            return View(province);
        }

        public ActionResult Create()
        {
            Province view = new Province();

            return View(view);
        }

        [HttpPost]
        public ActionResult Create(Province province)
        {
            if (!ModelState.IsValid)
            {
                return View(province);
            }
            else
            {
                context.Insert(province);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Province province = context.Find(Id);
            if (province == null)
            {
                return HttpNotFound();
            }
            else
            {
                Province view = new Province();

                return View(view);
            }
        }
        [HttpPost]
        public ActionResult Edit(Province province, string Id)
        {
            Province provinceToEdit = context.Find(Id);
            if (province == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(province);
                }
                provinceToEdit.Description = province.Description;

                context.Commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string Id)
        {
            Province provinceToEdit = context.Find(Id);
            if (provinceToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(provinceToEdit);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            Province provinceToDelete = context.Find(Id);
            if (provinceToDelete == null)
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