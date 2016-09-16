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
    public class horarioController : Controller
    {
        private BD db = new BD();

        // GET: horario
        public ActionResult Index()
        {
            var horario = db.horario.Include(h => h.dia);
            return View(horario.ToList());
        }

        // GET: horario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario horario = db.horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // GET: horario/Create
        public ActionResult Create()
        {
            ViewBag.Dia_Id = new SelectList(db.dia, "Id", "Dia_Semana");
            return View();
        }

        // POST: horario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HoraInicio,HoraFin,Dia_Id")] horario horario)
        {
            if (ModelState.IsValid)
            {
                db.horario.Add(horario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Dia_Id = new SelectList(db.dia, "Id", "Dia_Semana", horario.Dia_Id);
            return View(horario);
        }

        // GET: horario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario horario = db.horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Dia_Id = new SelectList(db.dia, "Id", "Dia_Semana", horario.Dia_Id);
            return View(horario);
        }

        // POST: horario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HoraInicio,HoraFin,Dia_Id")] horario horario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Dia_Id = new SelectList(db.dia, "Id", "Dia_Semana", horario.Dia_Id);
            return View(horario);
        }

        // GET: horario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            horario horario = db.horario.Find(id);
            if (horario == null)
            {
                return HttpNotFound();
            }
            return View(horario);
        }

        // POST: horario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            horario horario = db.horario.Find(id);
            db.horario.Remove(horario);
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
