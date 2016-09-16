using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using RellenoBD.Validations;

namespace RellenoBD
{
    [MetadataType(typeof(seccionMetadata))]
    public partial class seccion
    {
    }
    public class seccionMetadata
    {
        [Required(ErrorMessage = "Numero es Requerido")]
        [Range(1, 100000, ErrorMessage = "Numero debe ser entre 1 y 100000")]

        public Nullable<int> Numero { get; set; }
    }
}