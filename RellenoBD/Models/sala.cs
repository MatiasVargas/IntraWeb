using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RellenoBD.Validations;

namespace RellenoBD
{
    [MetadataType(typeof(salaMetadata))]

    public partial class sala
    {
    }
    public class salaMetadata
    {
        [SalaValidation]
        [Required(ErrorMessage = "Nombre es Requerido")]
        [StringLength(45, ErrorMessage = "Largo maximo 45 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Piso es requerido")]
        [Range(-5, 20, ErrorMessage = "Valor no valido")]
        public Nullable<int> Piso { get; set; }
    }
}