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
    public class asignaturaController : Controller
    {
        private BD db = new BD();

        // GET: asignatura
        public ActionResult Index()
        {
            return View(db.asignatura.ToList());
        }

        // GET: asignatura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asignatura asignatura = db.asignatura.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // GET: asignatura/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asignatura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Horas")] asignatura asignatura)
        {
                if (ModelState.IsValid)
                {
                    db.asignatura.Add(asignatura);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            return View(asignatura);
        }

        // GET: asignatura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asignatura asignatura = db.asignatura.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: asignatura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Horas")] asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asignatura);
        }

        // GET: asignatura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            asignatura asignatura = db.asignatura.Find(id);
            if (asignatura == null)
            {
                return HttpNotFound();
            }
            return View(asignatura);
        }

        // POST: asignatura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            asignatura asignatura = db.asignatura.Find(id);
            db.asignatura.Remove(asignatura);
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
