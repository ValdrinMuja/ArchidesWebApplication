using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace ArchidesArchitectureWeb.Controllers
{
    public class RoliController : Controller
    {
        // GET: Roli
        [HttpGet]
        public ActionResult Index()
        {
            return View(DataAcc.AccRoli.ShfaqRol());
        }
        

        // GET: Roli/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Models.Roli());
        }

        // POST: Roli/Create
        [HttpPost]
        public ActionResult Create(Models.Roli roli)
        {
            try
            {
                // TODO: Add insert logic here
                DataAcc.AccRoli.ShtoRol(roli);
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
            if (DataAcc.AccRoli.MerrRol(id)!=null)
            {
                return View(DataAcc.AccRoli.MerrRol(id));
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: Roli/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Roli roli)
        {
            try
            {
                // TODO: Add update logic here
                DataAcc.AccRoli.UpdateRol(roli);
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
