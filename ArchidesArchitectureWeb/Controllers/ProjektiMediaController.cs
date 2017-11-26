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
    public class ProjektiMediaController : Controller
    {
        private DBArchidesArchitetureEntities db = new DBArchidesArchitetureEntities();

        // GET: ProjektiMedia
        public ActionResult Index()
        {
            var projektiMedias = db.ProjektiMedias.Include(p => p.Medium).Include(p => p.Projekti);
            return View(projektiMedias.ToList());
        }

        // GET: ProjektiMedia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjektiMedia projektiMedia = db.ProjektiMedias.Find(id);
            if (projektiMedia == null)
            {
                return HttpNotFound();
            }
            return View(projektiMedia);
        }

        // GET: ProjektiMedia/Create
        public ActionResult Create()
        {
            ViewBag.LlojiArkitekturaID = new SelectList(db.LlojiArkitekturas, "LlojiArkitekturaID", "LlojiArkitektura1");
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaType1");
            ViewBag.MediaID = new SelectList(db.Media, "MediaID", "MediaPath");
            ViewBag.ProjektiID = new SelectList(db.Projektis, "ProjektiID", "Titulli");
            return View();
        }

        // POST: ProjektiMedia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjektiMediaID,ProjektiID,MediaID,Activ")] ProjektiMedia projektiMedia, [Bind(Include = "MediaID,MediaTypeID,LlojiArkitekturaID,MediaPath,Activ")] Medium media)
        {
            if (ModelState.IsValid)
            {
                db.Media.Add(media);
                db.SaveChanges();
                db.ProjektiMedias.Add(projektiMedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LlojiArkitekturaID = new SelectList(db.LlojiArkitekturas, "LlojiArkitekturaID", "LlojiArkitektura1", media.LlojiArkitekturaID);
            ViewBag.MediaTypeID = new SelectList(db.MediaTypes, "MediaTypeID", "MediaType1", media.MediaTypeID);
            ViewBag.MediaID = new SelectList(db.Media, "MediaID", "MediaPath", projektiMedia.MediaID);
            ViewBag.ProjektiID = new SelectList(db.Projektis, "ProjektiID", "Titulli", projektiMedia.ProjektiID);
            return View(projektiMedia);
        }

        // GET: ProjektiMedia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjektiMedia projektiMedia = db.ProjektiMedias.Find(id);
            if (projektiMedia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MediaID = new SelectList(db.Media, "MediaID", "MediaPath", projektiMedia.MediaID);
            ViewBag.ProjektiID = new SelectList(db.Projektis, "ProjektiID", "Titulli", projektiMedia.ProjektiID);
            return View(projektiMedia);
        }

        // POST: ProjektiMedia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjektiMediaID,ProjektiID,MediaID,Activ")] ProjektiMedia projektiMedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projektiMedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MediaID = new SelectList(db.Media, "MediaID", "MediaPath", projektiMedia.MediaID);
            ViewBag.ProjektiID = new SelectList(db.Projektis, "ProjektiID", "Titulli", projektiMedia.ProjektiID);
            return View(projektiMedia);
        }

        // GET: ProjektiMedia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjektiMedia projektiMedia = db.ProjektiMedias.Find(id);
            if (projektiMedia == null)
            {
                return HttpNotFound();
            }
            return View(projektiMedia);
        }

        // POST: ProjektiMedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjektiMedia projektiMedia = db.ProjektiMedias.Find(id);
            db.ProjektiMedias.Remove(projektiMedia);
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
