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
    
    public partial class asignatura
    {
        public asignatura()
        {
            this.carrera_asignatura = new HashSet<carrera_asignatura>();
            this.material = new HashSet<material>();
            this.seccion = new HashSet<seccion>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Horas { get; set; }
    
        public virtual ICollection<carrera_asignatura> carrera_asignatura { get; set; }
        public virtual ICollection<material> material { get; set; }
        public virtual ICollection<seccion> seccion { get; set; }
    }
}
