using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RellenoBD
{
    [MetadataType(typeof(notaMetadata))]

    public partial class nota
    {
    }
    public class notaMetadata
    {
        [Required(ErrorMessage ="Nota es Requerido")]
        [Range(1, 7, ErrorMessage = "Nota debe ser entre 1 y 7")]
        public Nullable<decimal> Nota1 { get; set; }
        [Required(ErrorMessage = "Ponderacion es Requerido")]
        [Range(1, 100, ErrorMessage = "Ponderacion debe ser entre 1 y 100")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Ponderacion debe ser numérico")]
        public Nullable<int> Ponderacion { get; set; }
        [Required(ErrorMessage = "Fecha es Requerido")]
        public Nullable<System.DateTime> Fecha { get; set; }
    }
}