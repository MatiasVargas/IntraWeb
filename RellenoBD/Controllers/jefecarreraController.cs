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
    public class jefecarreraController : Controller
    {
        private BD db = new BD();
        
        // GET: jefecarrera
        public ActionResult Index()
        {
            return View(db.jefecarrera.ToList());
        }

        // GET: jefecarrera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jefecarrera jefecarrera = db.jefecarrera.Find(id);
            if (jefecarrera == null)
            {
                return HttpNotFound();
            }
            return View(jefecarrera);
        }

        // GET: jefecarrera/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: jefecarrera/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Correo")] jefecarrera jefecarrera)
        {
            if (ModelState.IsValid)
            {
                db.jefecarrera.Add(jefecarrera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jefecarrera);
        }

        // GET: jefecarrera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jefecarrera jefecarrera = db.jefecarrera.Find(id);
            if (jefecarrera == null)
            {
                return HttpNotFound();
            }
            return View(jefecarrera);
        }

        // POST: jefecarrera/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Correo")] jefecarrera jefecarrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jefecarrera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jefecarrera);
        }

        // GET: jefecarrera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            jefecarrera jefecarrera = db.jefecarrera.Find(id);
            if (jefecarrera == null)
            {
                return HttpNotFound();
            }
            return View(jefecarrera);
        }

        // POST: jefecarrera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            jefecarrera jefecarrera = db.jefecarrera.Find(id);
            db.jefecarrera.Remove(jefecarrera);
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
