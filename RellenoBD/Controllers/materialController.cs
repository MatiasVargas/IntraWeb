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
    public class materialController : Controller
    {
        private BD db = new BD();

        // GET: material
        public ActionResult Index()
        {
            var material = db.material.Include(m => m.asignatura);
            return View(material.ToList());
        }

        // GET: material/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            material material = db.material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // GET: material/Create
        public ActionResult Create()
        {
            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre");
            return View();
        }

        // POST: material/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Archivo,Asignatura_Id")] material material)
        {
            if (ModelState.IsValid)
            {
                db.material.Add(material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre", material.Asignatura_Id);
            return View(material);
        }

        // GET: material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            material material = db.material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre", material.Asignatura_Id);
            return View(material);
        }

        // POST: material/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Archivo,Asignatura_Id")] material material)
        {
            if (ModelState.IsValid)
            {
                db.Entry(material).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asignatura_Id = new SelectList(db.asignatura, "Id", "Nombre", material.Asignatura_Id);
            return View(material);
        }

        // GET: material/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            material material = db.material.Find(id);
            if (material == null)
            {
                return HttpNotFound();
            }
            return View(material);
        }

        // POST: material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            material material = db.material.Find(id);
            db.material.Remove(material);
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
