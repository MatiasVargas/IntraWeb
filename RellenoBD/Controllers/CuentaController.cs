using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace RellenoBD.Controllers
{
    public class CuentaController : Controller
    {
        private object validationContext;

        // GET: Cuenta
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CuentaController user)
        {

            var model = (RellenoBD.usuario)validationContext;
            using (BD db = new BD())
            {
                var usr = db.usuario.Where(u => u.Nombre == model.Nombre && u.Contraseña == model.Contraseña).FirstOrDefault();
                if (usr != null)
                {
                    Session["Id"] = usr.Id.ToString();
                    Session["Nombre"] = usr.Nombre.ToString();
                    return RedirectToAction("Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o contraseña son incorrectos");
                }
            }

                return View();
        }
    }
}