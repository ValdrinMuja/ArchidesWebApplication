using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArchidesArchitectureWeb;

namespace ArchidesArchitectureWeb.Controllers
{
    public class RolisController : Controller
    {
        private DBArchidesArchitetureEntities db = new DBArchidesArchitetureEntities();

        // GET: Rolis
        public ActionResult Index()
        {
            return View(db.Rolis.ToList());
        }

        // GET: Rolis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roli roli = db.Rolis.Find(id);
            if (roli == null)
            {
                return HttpNotFound();
            }
            return View(roli);
        }

        // GET: Rolis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rolis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoliID,Roli1,Activ")] Roli roli)
        {
            if (ModelState.IsValid)
            {
                db.Rolis.Add(roli);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roli);
        }

        // GET: Rolis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roli roli = db.Rolis.Find(id);
            if (roli == null)
            {
                return HttpNotFound();
            }
            return View(roli);
        }

        // POST: Rolis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoliID,Roli1,Activ")] Roli roli)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roli).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roli);
        }

        // GET: Rolis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roli roli = db.Rolis.Find(id);
            if (roli == null)
            {
                return HttpNotFound();
            }
            return View(roli);
        }

        // POST: Rolis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roli roli = db.Rolis.Find(id);
            db.Rolis.Remove(roli);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
