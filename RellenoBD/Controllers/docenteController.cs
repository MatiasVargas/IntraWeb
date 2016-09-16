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
    public class docenteController : Controller
    {
        private BD db = new BD();

        // GET: docente
        public ActionResult Index()
        {
            return View(db.docente.ToList());
        }

        // GET: docente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            docente docente = db.docente.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // GET: docente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: docente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Correo")] docente docente)
        {
            if (ModelState.IsValid)
            {
                db.docente.Add(docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docente);
        }

        // GET: docente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            docente docente = db.docente.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: docente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Correo")] docente docente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        // GET: docente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            docente docente = db.docente.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: docente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            docente docente = db.docente.Find(id);
            db.docente.Remove(docente);
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
