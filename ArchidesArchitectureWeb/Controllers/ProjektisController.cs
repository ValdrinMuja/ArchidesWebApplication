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
    public class ProjektisController : Controller
    {
        private DBArchidesArchitetureEntities db = new DBArchidesArchitetureEntities();

        // GET: Projektis
        public ActionResult Index()
        {
            var projektis = db.Projektis.Include(p => p.Kategoria).Include(p => p.Useri);
            return View(projektis.ToList());
        }

        // GET: Projektis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekti projekti = db.Projektis.Find(id);
            if (projekti == null)
            {
                return HttpNotFound();
            }
            return View(projekti);
        }

        // GET: Projektis/Create
        public ActionResult Create()
        {
            ViewBag.KategoriaID = new SelectList(db.Kategorias, "KategoriaID", "Kategoria1");
            ViewBag.UserID = new SelectList(db.Useris, "UserID", "Emri");
            return View();
        }

        // POST: Projektis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjektiID,Titulli,Lokacioni,Viti,Madhesia,KategoriaID,Statusi,Pershkrimi,UploadTime,UserID,Activ")] Projekti projekti)
        {
            if (ModelState.IsValid)
            {
                db.Projektis.Add(projekti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KategoriaID = new SelectList(db.Kategorias, "KategoriaID", "Kategoria1", projekti.KategoriaID);
            ViewBag.UserID = new SelectList(db.Useris, "UserID", "Emri", projekti.UserID);
            return View(projekti);
        }

        // GET: Projektis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekti projekti = db.Projektis.Find(id);
            if (projekti == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriaID = new SelectList(db.Kategorias, "KategoriaID", "Kategoria1", projekti.KategoriaID);
            ViewBag.UserID = new SelectList(db.Useris, "UserID", "Emri", projekti.UserID);
            return View(projekti);
        }

        // POST: Projektis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjektiID,Titulli,Lokacioni,Viti,Madhesia,KategoriaID,Statusi,Pershkrimi,UploadTime,UserID,Activ")] Projekti projekti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projekti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KategoriaID = new SelectList(db.Kategorias, "KategoriaID", "Kategoria1", projekti.KategoriaID);
            ViewBag.UserID = new SelectList(db.Useris, "UserID", "Emri", projekti.UserID);
            return View(projekti);
        }

        // GET: Projektis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projekti projekti = db.Projektis.Find(id);
            if (projekti == null)
            {
                return HttpNotFound();
            }
            return View(projekti);
        }

        // POST: Projektis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Projekti projekti = db.Projektis.Find(id);
            db.Projektis.Remove(projekti);
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
