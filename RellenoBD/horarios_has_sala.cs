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
    
    public partial class horarios_has_sala
    {
        public int Sala_Id { get; set; }
        public int Horarios_has_Seccion_Horarios_Id { get; set; }
        public int Horarios_has_Seccion_Seccion_Id { get; set; }
    
        public virtual sala sala { get; set; }
    }
}
