using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RellenoBD.Validations;

namespace RellenoBD
{
    [MetadataType(typeof(alumnoMetadata))]
    public partial class alumno
    {       
    }

    public class alumnoMetadata
    {
        [RUTValidation]
        [Required(ErrorMessage = "Rut es requerido")]
        [StringLength(10, ErrorMessage = "Ingrese Rut como se muestra en ejemplo")]
        [MinLength(8, ErrorMessage = "Ingrese Rut Valido")]
        public string Rut { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(80, ErrorMessage = "Largo maximo 80 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Contraseña es requerido")]
        [StringLength(30, ErrorMessage = "Largo maximo 30 caracteres")]
        [DataType(DataType.Password)]

        public string Contraseña { get; set; }


        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress(ErrorMessage = "Email no tiene el formato correcto")]
        public string Correo { get; set; }
    }
}