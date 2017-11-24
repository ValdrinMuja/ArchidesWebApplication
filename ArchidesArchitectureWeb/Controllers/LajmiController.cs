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
    public class LajmiController : Controller
    {
        private DBArchidesArchitetureEntities db = new DBArchidesArchitetureEntities();

        // GET: Lajmi
        public ActionResult Index()
        {
            var lajmi = db.Lajmis.Include(l => l.Useri);
            return View(db.Lajmis.ToList());
        }

        // GET: Lajmi/Details/5
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

        // GET: Lajmi/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Useris, "UserID", "Emri");
            return View();
        }

        // POST: Lajmi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LajmiID,FotoPath,UploadTime,Titulli,Pershkrimi,UserID,Activ")] Lajmi lajmi)
        {
            if (ModelState.IsValid)
            {
                lajmi.UploadTime = DateTime.Now;
                db.Lajmis.Add(lajmi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lajmi);
        }

        // GET: Lajmi/Edit/5
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
            ViewBag.UserID = new SelectList(db.Useris, "UserID", "Emri", lajmi.UserID);
            return View(lajmi);
        }

        // POST: Lajmi/Edit/5
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
            ViewBag.UserID = new SelectList(db.Useris, "UserID", "Emri", lajmi.UserID);
            return View(lajmi);
        }

        // GET: Lajmi/Delete/5
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

        // POST: Lajmi/Delete/5
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
