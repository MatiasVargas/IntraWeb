using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RellenoBD.Views
{
    [MetadataType(typeof(LoginAdministradorMetadata))]
    public partial class LoginAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new BD();
                var admin = db.alumno;
                String nom = txtUsu.Text;
                String pass = txtContra.Text;
                foreach (var alumno in admin)

                if (alumno.Rut == nom && alumno.Contraseña == pass)
                {
                    Response.Redirect("Home");
                }
                else
                {
                    string script = "alert(\"No se encuentra usuario, verifique datos ingresados!\");";
                }
            }
            catch (Exception ex)
            {
                string script = "alert(\"Ha ocurrido un error!\");";
            }
        }

        public class LoginAdministradorMetadata
        {
            [Required(ErrorMessage = "El RUT es requerido")]
            public string rut { get; set; }
        }

    }
}