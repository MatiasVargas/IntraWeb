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
    public class asistenciaController : Controller
    {
        private BD db = new BD();

        // GET: asistencia
        public ActionResult Index()
        {
            var asistencia = db.asistencia.Include(a => a.alumno).Include(a => a.alumno_has_seccion);
            return View(asistencia.ToList());
        }

        // GET: asistencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asistencia asistencia = db.asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: asistencia/Create
        public ActionResult Create()
        {
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre");
            ViewBag.Alumno_has_Seccion_Id = new SelectList(db.alumno_has_seccion, "Id", "Seccion_Id");
            return View();
        }

        // POST: asistencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HorasAsist,Alumno_Rut,Alumno_has_Seccion_Id")] asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.asistencia.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", asistencia.Alumno_Rut);
            ViewBag.Alumno_has_Seccion_Id = new SelectList(db.alumno_has_seccion, "Id", "Alumno_Rut", asistencia.Alumno_has_Seccion_Id);
            return View(asistencia);
        }

        // GET: asistencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asistencia asistencia = db.asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", asistencia.Alumno_Rut);
            ViewBag.Alumno_has_Seccion_Id = new SelectList(db.alumno_has_seccion, "Id", "Alumno_Rut", asistencia.Alumno_has_Seccion_Id);
            return View(asistencia);
        }

        // POST: asistencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HorasAsist,Alumno_Rut,Alumno_has_Seccion_Id")] asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", asistencia.Alumno_Rut);
            ViewBag.Alumno_has_Seccion_Id = new SelectList(db.alumno_has_seccion, "Id", "Alumno_Rut", asistencia.Alumno_has_Seccion_Id);
            return View(asistencia);
        }

        // GET: asistencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asistencia asistencia = db.asistencia.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: asistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asistencia asistencia = db.asistencia.Find(id);
            db.asistencia.Remove(asistencia);
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
