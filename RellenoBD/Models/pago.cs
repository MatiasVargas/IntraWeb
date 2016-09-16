using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RellenoBD.Validations;

namespace RellenoBD
{
    [MetadataType(typeof(pagoMetadata))]
    public partial class pago
    {
    }
    public class pagoMetadata
    {
        [PagoValidation]
        [Required(ErrorMessage = "Estado es Requerido")]
        [StringLength(15, ErrorMessage = "Largo maximo 15 caracteres")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Fecha Vencimiento es Requerido")]
        public Nullable<System.DateTime> FechaVenc { get; set; }
        [Required(ErrorMessage = "Concepto es requerido")]
        [StringLength(45, ErrorMessage = "Largo maximo 45 caracteres")]
        [RegularExpression("^([a-zA-Z])*$", ErrorMessage = "Debe Ingresar Letras")]
        public string Concepto { get; set; }
        [Required(ErrorMessage = "Monto es Requerido")]
        [Range(1, 15000000, ErrorMessage = "Monto debe ser entre 1 y 15000000")]
        public Nullable<int> Monto { get; set; }
    }
}