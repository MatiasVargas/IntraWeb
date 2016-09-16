using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RellenoBD
{
    [MetadataType(typeof(usuarioMetadata))]
    public partial class usuario
    {
    }
    public class usuarioMetadata
    {
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(45, ErrorMessage = "Largo maximo 45 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Contraseña es requerido")]
        [StringLength(45, ErrorMessage = "Largo maximo 45 caracteres")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}