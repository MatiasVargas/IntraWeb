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
    public class horario_seccionController : Controller
    {
        private BD db = new BD();

        // GET: horario_seccion
        public ActionResult Index()
        {
            var horario_seccion = db.horario_seccion.Include(h => h.horario).Include(h => h.sala).Include(h => h.seccion);
            return View(horario_seccion.ToList());
        }

        // GET: horario_seccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario_seccion horario_seccion = db.horario_seccion.Find(id);
            if (horario_seccion == null)
            {
                return HttpNotFound();
            }
            return View(horario_seccion);
        }

        // GET: horario_seccion/Create
        public ActionResult Create()
        {
            ViewBag.Horario_Id = new SelectList(db.horario, "Id", "Id");
            ViewBag.Sala_Id = new SelectList(db.sala, "Id", "Nombre");
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Numero");
            return View();
        }

        // POST: horario_seccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Horario_Id,Seccion_Id,Sala_Id")] horario_seccion horario_seccion)
        {
            if (ModelState.IsValid)
            {
                db.horario_seccion.Add(horario_seccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Horario_Id = new SelectList(db.horario, "Id", "Id", horario_seccion.Horario_Id);
            ViewBag.Sala_Id = new SelectList(db.sala, "Id", "Nombre", horario_seccion.Sala_Id);
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Id", horario_seccion.Seccion_Id);
            return View(horario_seccion);
        }

        // GET: horario_seccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario_seccion horario_seccion = db.horario_seccion.Find(id);
            if (horario_seccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Horario_Id = new SelectList(db.horario, "Id", "Id", horario_seccion.Horario_Id);
            ViewBag.Sala_Id = new SelectList(db.sala, "Id", "Nombre", horario_seccion.Sala_Id);
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Numero", horario_seccion.Seccion_Id);
            return View(horario_seccion);
        }

        // POST: horario_seccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Horario_Id,Seccion_Id,Sala_Id")] horario_seccion horario_seccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario_seccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Horario_Id = new SelectList(db.horario, "Id", "Id", horario_seccion.Horario_Id);
            ViewBag.Sala_Id = new SelectList(db.sala, "Id", "Nombre", horario_seccion.Sala_Id);
            ViewBag.Seccion_Id = new SelectList(db.seccion, "Id", "Id", horario_seccion.Seccion_Id);
            return View(horario_seccion);
        }

        // GET: horario_seccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario_seccion horario_seccion = db.horario_seccion.Find(id);
            if (horario_seccion == null)
            {
                return HttpNotFound();
            }
            return View(horario_seccion);
        }

        // POST: horario_seccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            horario_seccion horario_seccion = db.horario_seccion.Find(id);
            db.horario_seccion.Remove(horario_seccion);
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
