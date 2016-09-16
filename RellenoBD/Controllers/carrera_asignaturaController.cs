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
    public class carrera_asignaturaController : Controller
    {
        private BD db = new BD();

        // GET: carrera_asignatura
        public ActionResult Index()
        {
            var carrera_asignatura = db.carrera_asignatura.Include(c => c.asignatura).Include(c => c.carrera);
            return View(carrera_asignatura.ToList());
        }

        // GET: carrera_asignatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera_asignatura carrera_asignatura = db.carrera_asignatura.Find(id);
            if (carrera_asignatura == null)
            {
                return HttpNotFound();
            }
            return View(carrera_asignatura);
        }

        // GET: carrera_asignatura/Create
        public ActionResult Create()
        {
            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre");
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre");
            return View();
        }

        // POST: carrera_asignatura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Carrera_Id,Asignatura_Id,Id")] carrera_asignatura carrera_asignatura)
        {
            if (ModelState.IsValid)
            {
                db.carrera_asignatura.Add(carrera_asignatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre", carrera_asignatura.Asignatura_Id);
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre", carrera_asignatura.Carrera_Id);
            return View(carrera_asignatura);
        }

        // GET: carrera_asignatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera_asignatura carrera_asignatura = db.carrera_asignatura.Find(id);
            if (carrera_asignatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre", carrera_asignatura.Asignatura_Id);
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre", carrera_asignatura.Carrera_Id);
            return View(carrera_asignatura);
        }

        // POST: carrera_asignatura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Carrera_Id,Asignatura_Id,Id")] carrera_asignatura carrera_asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrera_asignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre", carrera_asignatura.Asignatura_Id);
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre", carrera_asignatura.Carrera_Id);
            return View(carrera_asignatura);
        }

        // GET: carrera_asignatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera_asignatura carrera_asignatura = db.carrera_asignatura.Find(id);
            if (carrera_asignatura == null)
            {
                return HttpNotFound();
            }
            return View(carrera_asignatura);
        }

        // POST: carrera_asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carrera_asignatura carrera_asignatura = db.carrera_asignatura.Find(id);
            db.carrera_asignatura.Remove(carrera_asignatura);
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
