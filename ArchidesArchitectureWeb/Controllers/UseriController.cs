using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArchidesArchitectureWeb;
using System.IO;

namespace ArchidesArchitectureWeb.Controllers
{
    public class UseriController : Controller
    {
        private DBArchidesArchitetureEntities db = new DBArchidesArchitetureEntities();

        // GET: Useri
        public ActionResult Index()
        {
            var useris = db.Useris.Include(u => u.Roli);
            return View(useris.ToList());
        }

        // GET: Useri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Useri useri = db.Useris.Find(id);
            if (useri == null)
            {
                return HttpNotFound();
            }
            return View(useri);
        }

        // GET: Useri/Create
        public ActionResult Create()
        {
            ViewBag.RoliID = new SelectList(db.Rolis, "RoliID", "Roli1");
            return View();
        }

        // POST: Useri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Emri,Mbiemri,Gjinia,Vendlindja,Datelindja,Email,Telefoni,Username,Password,Pershkrimi,Shkollimi,PergaditjaProfesionale,Foto,RoliID,Activ")] Useri useri)
        {
            if (ModelState.IsValid)
            {

                string fileName = Path.GetFileNameWithoutExtension(useri.ImageFile.FileName);
                string extension = Path.GetExtension(useri.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssffff") + extension;
                useri.Foto = "~/PhotoUser/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                useri.ImageFile.SaveAs(fileName);

                db.Useris.Add(useri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoliID = new SelectList(db.Rolis, "RoliID", "Roli1", useri.RoliID);
            
            return View(useri);
        }

        // GET: Useri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Useri useri = db.Useris.Find(id);
            if (useri == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoliID = new SelectList(db.Rolis, "RoliID", "Roli1", useri.RoliID);
            return View(useri);
        }

        // POST: Useri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Emri,Mbiemri,Gjinia,Vendlindja,Datelindja,Email,Telefoni,Username,Password,Pershkrimi,Shkollimi,PergaditjaProfesionale,Foto,RoliID,Activ")] Useri useri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(useri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoliID = new SelectList(db.Rolis, "RoliID", "Roli1", useri.RoliID);
            return View(useri);
        }

        // GET: Useri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Useri useri = db.Useris.Find(id);
            if (useri == null)
            {
                return HttpNotFound();
            }
            return View(useri);
        }

        // POST: Useri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Useri useri = db.Useris.Find(id);
            db.Useris.Remove(useri);
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
