using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperMVC.Models;

namespace DapperMVC.Controllers
{
    public class ManufacturerController : Controller
    {
        // GET: Manufacturer
        ManufacturerRepository repo = new ManufacturerRepository();
        public ActionResult Index()
        {
            return View(repo.GetManufacturers());
        }

        // GET: Manufacturer/Details/5
        public ActionResult Details(int id)
        {
            Manufacturer manufacturer = repo.Get(id);
            if (manufacturer != null)
                return View(manufacturer);
            return HttpNotFound();
        }

        // GET: Manufacturer/Create
        [HttpPost]
        public ActionResult Create(Manufacturer manufacturer)
        {
            repo.Create(manufacturer);
            return RedirectToAction("Index");
        }

        // POST: Manufacturer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manufacturer/Edit/5
        public ActionResult Edit(int id)
        {
            Manufacturer manufacturer = repo.Get(id);
            if (manufacturer != null)
                return View(manufacturer);
            return HttpNotFound();
        }

        // POST: Manufacturer/Edit/5
        [HttpPost]
        public ActionResult Edit(Manufacturer manufacturer)
        {
            repo.Update(manufacturer);
            return RedirectToAction("Index");
        }

        // GET: Manufacturer/Delete/5
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Manufacturer manufacturer = repo.Get(id);
            if (manufacturer != null)
                return View(manufacturer);
            return HttpNotFound();
        }

        // POST: Manufacturer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
