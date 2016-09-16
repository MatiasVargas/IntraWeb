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
    public class diaController : Controller
    {
        private BD db = new BD();

        // GET: dia
        public ActionResult Index()
        {
            return View(db.dia.ToList());
        }

        // GET: dia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dia dia = db.dia.Find(id);
            if (dia == null)
            {
                return HttpNotFound();
            }
            return View(dia);
        }

        // GET: dia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dia_Semana")] dia dia)
        {
            if (ModelState.IsValid)
            {
                db.dia.Add(dia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dia);
        }

        // GET: dia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dia dia = db.dia.Find(id);
            if (dia == null)
            {
                return HttpNotFound();
            }
            return View(dia);
        }

        // POST: dia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dia_Semana")] dia dia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dia);
        }

        // GET: dia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dia dia = db.dia.Find(id);
            if (dia == null)
            {
                return HttpNotFound();
            }
            return View(dia);
        }

        // POST: dia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dia dia = db.dia.Find(id);
            db.dia.Remove(dia);
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
