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
    public class carrera_jefecarreraController : Controller
    {
        private BD db = new BD();

        // GET: carrera_jefecarrera
        public ActionResult Index()
        {
            var carrera_jefecarrera = db.carrera_jefecarrera.Include(c => c.carrera).Include(c => c.jefecarrera);
            return View(carrera_jefecarrera.ToList());
        }

        // GET: carrera_jefecarrera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera_jefecarrera carrera_jefecarrera = db.carrera_jefecarrera.Find(id);
            if (carrera_jefecarrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera_jefecarrera);
        }

        // GET: carrera_jefecarrera/Create
        public ActionResult Create()
        {
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre");
            ViewBag.JefeCarrera_Id = new SelectList(db.jefecarrera, "Id", "Nombre");
            return View();
        }

        // POST: carrera_jefecarrera/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Carrera_Id,JefeCarrera_Id,Id")] carrera_jefecarrera carrera_jefecarrera)
        {
            if (ModelState.IsValid)
            {
                db.carrera_jefecarrera.Add(carrera_jefecarrera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre", carrera_jefecarrera.Carrera_Id);
            ViewBag.JefeCarrera_Id = new SelectList(db.jefecarrera, "Id", "Nombre", carrera_jefecarrera.JefeCarrera_Id);
            return View(carrera_jefecarrera);
        }

        // GET: carrera_jefecarrera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera_jefecarrera carrera_jefecarrera = db.carrera_jefecarrera.Find(id);
            if (carrera_jefecarrera == null)
            {
                return HttpNotFound();
            }
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre", carrera_jefecarrera.Carrera_Id);
            ViewBag.JefeCarrera_Id = new SelectList(db.jefecarrera, "Id", "Nombre", carrera_jefecarrera.JefeCarrera_Id);
            return View(carrera_jefecarrera);
        }

        // POST: carrera_jefecarrera/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Carrera_Id,JefeCarrera_Id,Id")] carrera_jefecarrera carrera_jefecarrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrera_jefecarrera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre", carrera_jefecarrera.Carrera_Id);
            ViewBag.JefeCarrera_Id = new SelectList(db.jefecarrera, "Id", "Nombre", carrera_jefecarrera.JefeCarrera_Id);
            return View(carrera_jefecarrera);
        }

        // GET: carrera_jefecarrera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera_jefecarrera carrera_jefecarrera = db.carrera_jefecarrera.Find(id);
            if (carrera_jefecarrera == null)
            {
                return HttpNotFound();
            }
            return View(carrera_jefecarrera);
        }

        // POST: carrera_jefecarrera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carrera_jefecarrera carrera_jefecarrera = db.carrera_jefecarrera.Find(id);
            db.carrera_jefecarrera.Remove(carrera_jefecarrera);
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
