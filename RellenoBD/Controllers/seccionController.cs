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
    public class seccionController : Controller
    {
        private BD db = new BD();

        // GET: seccion
        public ActionResult Index()
        {
            var seccion = db.seccion.Include(s => s.asignatura).Include(s => s.docente);
            return View(seccion.ToList());
        }

        // GET: seccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seccion seccion = db.seccion.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // GET: seccion/Create
        public ActionResult Create()
        {
            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre");
            ViewBag.Docente_Id = new SelectList(db.docente, "Id", "Nombre");
            return View();
        }

        // POST: seccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,Docente_Id,Asignatura_Id")] seccion seccion)
        {
            if (ModelState.IsValid)
            {
                db.seccion.Add(seccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre", seccion.Asignatura_Id);
            ViewBag.Docente_Id = new SelectList(db.docente, "Id", "Nombre", seccion.Docente_Id);
            return View(seccion);
        }

        // GET: seccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seccion seccion = db.seccion.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre", seccion.Asignatura_Id);
            ViewBag.Docente_Id = new SelectList(db.docente, "Id", "Nombre", seccion.Docente_Id);
            return View(seccion);
        }

        // POST: seccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,Docente_Id,Asignatura_Id")] seccion seccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre", seccion.Asignatura_Id);
            ViewBag.Docente_Id = new SelectList(db.docente, "Id", "Nombre", seccion.Docente_Id);
            return View(seccion);
        }

        // GET: seccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            seccion seccion = db.seccion.Find(id);
            if (seccion == null)
            {
                return HttpNotFound();
            }
            return View(seccion);
        }

        // POST: seccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            seccion seccion = db.seccion.Find(id);
            db.seccion.Remove(seccion);
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
