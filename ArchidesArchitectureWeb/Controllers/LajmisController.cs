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
    public class LajmisController : Controller
    {
        private DBArchidesArchitetureEntities db = new DBArchidesArchitetureEntities();

        // GET: Lajmis
        public ActionResult Index()
        {
            return View(db.Lajmis.ToList());
        }

        // GET: Lajmis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lajmi lajmi = db.Lajmis.Find(id);
            if (lajmi == null)
            {
                return HttpNotFound();
            }
            return View(lajmi);
        }

        // GET: Lajmis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lajmis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LajmiID,FotoPath,UploadTime,Titulli,Pershkrimi,Activ")] Lajmi lajmi)
        {
            if (ModelState.IsValid)
            {
                db.Lajmis.Add(lajmi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lajmi);
        }

        // GET: Lajmis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lajmi lajmi = db.Lajmis.Find(id);
            if (lajmi == null)
            {
                return HttpNotFound();
            }
            return View(lajmi);
        }

        // POST: Lajmis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LajmiID,FotoPath,UploadTime,Titulli,Pershkrimi,Activ")] Lajmi lajmi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lajmi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lajmi);
        }

        // GET: Lajmis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lajmi lajmi = db.Lajmis.Find(id);
            if (lajmi == null)
            {
                return HttpNotFound();
            }
            return View(lajmi);
        }

        // POST: Lajmis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lajmi lajmi = db.Lajmis.Find(id);
            db.Lajmis.Remove(lajmi);
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
