using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchidesArchitectureWeb.Controllers
{
    public class RoliController : Controller
    {
        // GET: Roli
        public ActionResult Index()
        {
            return View();
        }

        // GET: Roli/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roli/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roli/Create
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

        // GET: Roli/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Roli/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roli/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Roli/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
