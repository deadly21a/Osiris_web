﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PrometeoAdminEntities : DbContext
    {
        public PrometeoAdminEntities()
            : base("name=PrometeoAdminEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAdUsuario> tblAdUsuario { get; set; }
        public virtual DbSet<View_Rh_Cargos> View_Rh_Cargos { get; set; }
        public virtual DbSet<ZPLA_DETA_GENTIX_EMPLEADOS> ZPLA_DETA_GENTIX_EMPLEADOS { get; set; }
        public virtual DbSet<ZPLA_DETA_OPCIONES> ZPLA_DETA_OPCIONES { get; set; }
        public virtual DbSet<ZPLA_VIEW_GENITX_AREA_DPTO> ZPLA_VIEW_GENITX_AREA_DPTO { get; set; }
        public virtual DbSet<ZPLA_VIEW_USUARIOS> ZPLA_VIEW_USUARIOS { get; set; }
    }
}