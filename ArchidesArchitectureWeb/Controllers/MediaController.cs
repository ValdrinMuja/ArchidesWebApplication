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
    public class MediaController : Controller
    {
        private DBArchidesArchitetureEntities db = new DBArchidesArchitetureEntities();

        // GET: Media
        public ActionResult Index()
        {
            var media = db.Media.Include(m => m.LlojiArkitektura).Include(m => m.MediaType);
            return View(media.ToList());
        }

        // GET: Media/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medium medium = db.Media.Find(id);
            if (medium == null)
            {
                return HttpNotFound();
            }
            return View(medium);
        }

        // GET: Media/Create
        public ActionResult Create()
        {
            ViewBag.LlojiArkitekturaID = new SelectList(db.LlojiArkitekturas, "LlojiArkitekturaID", "LlojiArkitektura1");
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaType1");
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MediaID,MediaTypeID,LlojiArkitekturaID,MediaPath,Activ")] Medium medium)
        {
            if (ModelState.IsValid)
            {
                db.Media.Add(medium);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LlojiArkitekturaID = new SelectList(db.LlojiArkitekturas, "LlojiArkitekturaID", "LlojiArkitektura1", medium.LlojiArkitekturaID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaType1", medium.MediaTypeID);
            return View(medium);
        }

        // GET: Media/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medium medium = db.Media.Find(id);
            if (medium == null)
            {
                return HttpNotFound();
            }
            ViewBag.LlojiArkitekturaID = new SelectList(db.LlojiArkitekturas, "LlojiArkitekturaID", "LlojiArkitektura1", medium.LlojiArkitekturaID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaType1", medium.MediaTypeID);
            return View(medium);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MediaID,MediaTypeID,LlojiArkitekturaID,MediaPath,Activ")] Medium medium)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medium).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LlojiArkitekturaID = new SelectList(db.LlojiArkitekturas, "LlojiArkitekturaID", "LlojiArkitektura1", medium.LlojiArkitekturaID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaType1", medium.MediaTypeID);
            return View(medium);
        }

        // GET: Media/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medium medium = db.Media.Find(id);
            if (medium == null)
            {
                return HttpNotFound();
            }
            return View(medium);
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medium medium = db.Media.Find(id);
            db.Media.Remove(medium);
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
