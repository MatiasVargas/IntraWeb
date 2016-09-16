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
    public class pagoController : Controller
    {
        private BD db = new BD();

        // GET: pago
        public ActionResult Index()
        {
            var pago = db.pago.Include(p => p.alumno);
            return View(pago.ToList());
        }

        // GET: pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pago pago = db.pago.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: pago/Create
        public ActionResult Create()
        {
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre");
            return View();
        }

        // POST: pago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Estado,FechaVenc,Concepto,Monto,Alumno_Rut")] pago pago)
        {
            if (ModelState.IsValid)
            {
                db.pago.Add(pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", pago.Alumno_Rut);
            return View(pago);
        }

        // GET: pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pago pago = db.pago.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", pago.Alumno_Rut);
            return View(pago);
        }

        // POST: pago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Estado,FechaVenc,Concepto,Monto,Alumno_Rut")] pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alumno_Rut = new SelectList(db.alumno, "Rut", "Nombre", pago.Alumno_Rut);
            return View(pago);
        }

        // GET: pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pago pago = db.pago.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pago pago = db.pago.Find(id);
            db.pago.Remove(pago);
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
