﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BD : DbContext
    {
        public BD()
            : base("name=BD")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<alarma> alarma { get; set; }
        public DbSet<alumno> alumno { get; set; }
        public DbSet<alumno_has_alarma> alumno_has_alarma { get; set; }
        public DbSet<alumno_has_seccion> alumno_has_seccion { get; set; }
        public DbSet<asignatura> asignatura { get; set; }
        public DbSet<asistencia> asistencia { get; set; }
        public DbSet<carrera> carrera { get; set; }
        public DbSet<carrera_asignatura> carrera_asignatura { get; set; }
        public DbSet<carrera_jefecarrera> carrera_jefecarrera { get; set; }
        public DbSet<dia> dia { get; set; }
        public DbSet<docente> docente { get; set; }
        public DbSet<horario> horario { get; set; }
        public DbSet<horario_seccion> horario_seccion { get; set; }
        public DbSet<horarios_has_sala> horarios_has_sala { get; set; }
        public DbSet<jefecarrera> jefecarrera { get; set; }
        public DbSet<material> material { get; set; }
        public DbSet<nota> nota { get; set; }
        public DbSet<pago> pago { get; set; }
        public DbSet<sala> sala { get; set; }
        public DbSet<seccion> seccion { get; set; }
        public DbSet<usuario> usuario { get; set; }
    }
}
