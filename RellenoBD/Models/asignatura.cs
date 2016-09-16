using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RellenoBD.Validations;

namespace RellenoBD
{
    [MetadataType(typeof(asignaturaMetadata))]
    public partial class asignatura
    { 
    }

    public class asignaturaMetadata
    {
        [AsignaturaValidation]
        [Required(ErrorMessage = "Nombre es Requerido")]
        [StringLength(80, ErrorMessage = "Largo maximo 80 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Horas es requerido")]
        [Range(0, 300, ErrorMessage = "Cantidad de horas no valido")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debe ser numérico mayor que 0")]
        public Nullable<int> Horas { get; set; }
    }
}