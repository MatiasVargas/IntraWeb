using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RellenoBD.Controllers
{
    public class SesionController : Controller
    {
        // GET: Sesion
        public ActionResult Index()
        {
            return View();
        }

        public void iniciarSesion(string rut, string contra)
        {
            Response.Write("<script>window.alert('Datos recibidos'"+rut+contra+"');</script>");
        }
    }
}