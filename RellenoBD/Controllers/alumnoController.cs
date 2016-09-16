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
    public class alumnoController : Controller
    {
        private BD db = new BD();

        // GET: alumno
        public ActionResult Index()
        {
            var alumno = db.alumno.Include(a => a.carrera);
            return View(alumno.ToList());
        }

        // GET: alumno/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumno alumno = db.alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // GET: alumno/Create
        public ActionResult Create()
        {
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre");
            return View();
        }

        // POST: alumno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Rut,Nombre,Contraseña,Correo,Carrera_Id")] alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.alumno.Add(alumno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
       
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre", alumno.Carrera_Id);
            return View(alumno);
        }

        // GET: alumno/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumno alumno = db.alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre", alumno.Carrera_Id);
            return View(alumno);
        }

        // POST: alumno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Rut,Nombre,Contraseña,Correo,Carrera_Id")] alumno alumno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Carrera_Id = new SelectList(db.carrera, "Id", "Nombre", alumno.Carrera_Id);
            return View(alumno);
        }

        // GET: alumno/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumno alumno = db.alumno.Find(id);
            if (alumno == null)
            {
                return HttpNotFound();
            }
            return View(alumno);
        }

        // POST: alumno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            alumno alumno = db.alumno.Find(id);
            db.alumno.Remove(alumno);
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