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
    
    public partial class seccion
    {
        public seccion()
        {
            this.alumno_has_seccion = new HashSet<alumno_has_seccion>();
            this.horario_seccion = new HashSet<horario_seccion>();
            this.nota = new HashSet<nota>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Numero { get; set; }
        public int Docente_Id { get; set; }
        public int Asignatura_Id { get; set; }
    
        public virtual ICollection<alumno_has_seccion> alumno_has_seccion { get; set; }
        public virtual asignatura asignatura { get; set; }
        public virtual docente docente { get; set; }
        public virtual ICollection<horario_seccion> horario_seccion { get; set; }
        public virtual ICollection<nota> nota { get; set; }
    }
}