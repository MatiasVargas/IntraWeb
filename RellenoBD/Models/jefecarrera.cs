using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RellenoBD.Validations;

namespace RellenoBD
{
    [MetadataType(typeof(jefecarreraMetadata))]
    public partial class jefecarrera
    {
    }
    public class jefecarreraMetadata
    {
        [JefeCarreraValidation]
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(80, ErrorMessage = "Largo maximo 80 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress(ErrorMessage = "Email no tiene el formato correcto")]
        public string Correo { get; set; }
    }
}