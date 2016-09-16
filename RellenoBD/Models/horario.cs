using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RellenoBD
{
    [MetadataType(typeof(horarioMetadata))]
    public partial class horario
    {
        
    }
    public class horarioMetadata
    {
        [Required(ErrorMessage ="Hora Inicio es requerido")]
        public Nullable<System.TimeSpan> HoraInicio { get; set; }
        [Required(ErrorMessage = "Hora Fin es requerido")]
        public Nullable<System.TimeSpan> HoraFin { get; set; }
    }
}