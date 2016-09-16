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
    public class salaController : Controller
    {
        private BD db = new BD();

        // GET: sala
        public ActionResult Index()
        {
            var sala = db.sala.Include(s => s.horarios_has_sala);
            return View(sala.ToList());
        }

        // GET: sala/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sala sala = db.sala.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // GET: sala/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.horarios_has_sala, "Sala_Id", "Sala_Id");
            return View();
        }

        // POST: sala/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Piso")] sala sala)
        {
            if (ModelState.IsValid)
            {
                db.sala.Add(sala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.horarios_has_sala, "Sala_Id", "Sala_Id", sala.Id);
            return View(sala);
        }

        // GET: sala/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sala sala = db.sala.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.horarios_has_sala, "Sala_Id", "Sala_Id", sala.Id);
            return View(sala);
        }

        // POST: sala/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Piso")] sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.horarios_has_sala, "Sala_Id", "Sala_Id", sala.Id);
            return View(sala);
        }

        // GET: sala/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sala sala = db.sala.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // POST: sala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sala sala = db.sala.Find(id);
            db.sala.Remove(sala);
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
