using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RellenoBD.Validations;
using System.Linq;
using System.Web;

namespace RellenoBD
{
    [MetadataType(typeof(carreraMetadata))]
    public partial class carrera
    {
    }
    public class carreraMetadata
    {
        [CarreraValidation]
        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(50, ErrorMessage = "Largo maximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Monto Anual es requerido")]
        [Range(0, 10000000, ErrorMessage = "Monto ingresado no valido")]
        [DataType(DataType.Currency)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Debe ser numérico mayor que 0")]
        public Nullable<int> MontoAnual { get; set; }
    }
}