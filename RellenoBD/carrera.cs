//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RellenoBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class carrera
    {
        public carrera()
        {
            this.alumno = new HashSet<alumno>();
            this.carrera_asignatura = new HashSet<carrera_asignatura>();
            this.carrera_jefecarrera = new HashSet<carrera_jefecarrera>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> MontoAnual { get; set; }
    
        public virtual ICollection<alumno> alumno { get; set; }
        public virtual ICollection<carrera_asignatura> carrera_asignatura { get; set; }
        public virtual ICollection<carrera_jefecarrera> carrera_jefecarrera { get; set; }
    }
}
