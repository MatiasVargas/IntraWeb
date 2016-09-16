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
    public class notaController : Controller
    {
        private BD db = new BD();

        // GET: nota
        public ActionResult Index()
        {
            var nota = db.nota.Include(n => n.alumno).Include(n => n.seccion);
            return View(nota.ToList());
        }

        // GET: nota/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nota nota = db.nota.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // GET: nota/Create
        public ActionResult Create()
        {
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre");
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Numero");
            return View();
        }

        // POST: nota/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nota1,Ponderacion,Fecha,Alumno_Rut,Seccion_Id")] nota nota)
        {
            if (ModelState.IsValid)
            {
                db.nota.Add(nota);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", nota.Alumno_Rut);
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Id", nota.Seccion_Id);
            return View(nota);
        }

        // GET: nota/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nota nota = db.nota.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", nota.Alumno_Rut);
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Numero", nota.Seccion_Id);
            return View(nota);
        }

        // POST: nota/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nota1,Ponderacion,Fecha,Alumno_Rut,Seccion_Id")] nota nota)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nota).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", nota.Alumno_Rut);
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Id", nota.Seccion_Id);
            return View(nota);
        }

        // GET: nota/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            nota nota = db.nota.Find(id);
            if (nota == null)
            {
                return HttpNotFound();
            }
            return View(nota);
        }

        // POST: nota/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            nota nota = db.nota.Find(id);
            db.nota.Remove(nota);
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
