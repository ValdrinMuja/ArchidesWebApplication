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
    public class LlojiArkitekturasController : Controller
    {
        private DBArchidesArchitetureEntities db = new DBArchidesArchitetureEntities();

        // GET: LlojiArkitekturas
        public ActionResult Index()
        {
            return View(db.LlojiArkitekturas.ToList());
        }

        // GET: LlojiArkitekturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlojiArkitektura llojiArkitektura = db.LlojiArkitekturas.Find(id);
            if (llojiArkitektura == null)
            {
                return HttpNotFound();
            }
            return View(llojiArkitektura);
        }

        // GET: LlojiArkitekturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LlojiArkitekturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LlojiArkitekturaID,LlojiArkitektura1,Activ")] LlojiArkitektura llojiArkitektura)
        {
            if (ModelState.IsValid)
            {
                db.LlojiArkitekturas.Add(llojiArkitektura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(llojiArkitektura);
        }

        // GET: LlojiArkitekturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlojiArkitektura llojiArkitektura = db.LlojiArkitekturas.Find(id);
            if (llojiArkitektura == null)
            {
                return HttpNotFound();
            }
            return View(llojiArkitektura);
        }

        // POST: LlojiArkitekturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LlojiArkitekturaID,LlojiArkitektura1,Activ")] LlojiArkitektura llojiArkitektura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(llojiArkitektura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(llojiArkitektura);
        }

        // GET: LlojiArkitekturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LlojiArkitektura llojiArkitektura = db.LlojiArkitekturas.Find(id);
            if (llojiArkitektura == null)
            {
                return HttpNotFound();
            }
            return View(llojiArkitektura);
        }

        // POST: LlojiArkitekturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LlojiArkitektura llojiArkitektura = db.LlojiArkitekturas.Find(id);
            db.LlojiArkitekturas.Remove(llojiArkitektura);
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
