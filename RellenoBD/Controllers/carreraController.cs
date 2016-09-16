using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RellenoBD;

namespace RellenoBD.Controllers
{
    public class carreraController : Controller
    {
        private BD db = new BD();

        // GET: carrera
        public ActionResult Index()
        {
            return View(db.carrera.ToList());
        }

        // GET: carrera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera carrera = db.carrera.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        // GET: carrera/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: carrera/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,MontoAnual")] carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.carrera.Add(carrera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(carrera);
        }

        // GET: carrera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera carrera = db.carrera.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        // POST: carrera/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,MontoAnual")] carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrera);
        }

        // GET: carrera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera carrera = db.carrera.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera);
        }

        // POST: carrera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carrera carrera = db.carrera.Find(id);
            db.carrera.Remove(carrera);
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
