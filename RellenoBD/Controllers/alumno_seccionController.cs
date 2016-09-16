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
    public class alumno_seccionController : Controller
    {
        private BD db = new BD();

        // GET: alumno_seccion
        public ActionResult Index()
        {
            var alumno_has_seccion = db.alumno_has_seccion.Include(a => a.alumno).Include(a => a.seccion);
            return View(alumno_has_seccion.ToList());
        }

        // GET: alumno_seccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumno_has_seccion alumno_has_seccion = db.alumno_has_seccion.Find(id);
            if (alumno_has_seccion == null)
            {
                return HttpNotFound();
            }
            return View(alumno_has_seccion);
        }

        // GET: alumno_seccion/Create
        public ActionResult Create()
        {
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre");
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Numero");
            return View();
        }

        // POST: alumno_seccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Alumno_Rut,Seccion_Id")] alumno_has_seccion alumno_has_seccion)
        {
            if (ModelState.IsValid)
            {
                db.alumno_has_seccion.Add(alumno_has_seccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", alumno_has_seccion.Alumno_Rut);
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Id", alumno_has_seccion.Seccion_Id);
            return View(alumno_has_seccion);
        }

        // GET: alumno_seccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumno_has_seccion alumno_has_seccion = db.alumno_has_seccion.Find(id);
            if (alumno_has_seccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", alumno_has_seccion.Alumno_Rut);
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Numero", alumno_has_seccion.Seccion_Id);
            return View(alumno_has_seccion);
        }

        // POST: alumno_seccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Alumno_Rut,Seccion_Id")] alumno_has_seccion alumno_has_seccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumno_has_seccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", alumno_has_seccion.Alumno_Rut);
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Id", alumno_has_seccion.Seccion_Id);
            return View(alumno_has_seccion);
        }

        // GET: alumno_seccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            alumno_has_seccion alumno_has_seccion = db.alumno_has_seccion.Find(id);
            if (alumno_has_seccion == null)
            {
                return HttpNotFound();
            }
            return View(alumno_has_seccion);
        }

        // POST: alumno_seccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            alumno_has_seccion alumno_has_seccion = db.alumno_has_seccion.Find(id);
            db.alumno_has_seccion.Remove(alumno_has_seccion);
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
