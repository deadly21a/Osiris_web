//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class RevisionRequerimiento
    {
        public int ID_RevisionRequerimiento { get; set; }
        public int ID_ingreso_requerimiento { get; set; }
        public Nullable<int> ID_Estado { get; set; }
        public Nullable<int> ID_Solicitante { get; set; }
        public Nullable<int> ID_Tipo_requerimiento { get; set; }
        public Nullable<int> ID_Prioridad { get; set; }
        public string Requerimiento { get; set; }
        public Nullable<int> ID_Proyecto { get; set; }
        public Nullable<int> ID_Aplicacion { get; set; }
        public string Opcion { get; set; }
        public Nullable<int> ID_Hardware { get; set; }
        public string Comentario { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public Nullable<System.DateTime> F_Plazo { get; set; }
        public Nullable<System.DateTime> F_revision { get; set; }
        public string Comentario_rev { get; set; }
        public Nullable<decimal> Duracion_Hr { get; set; }
        public Nullable<int> ID_Usuario { get; set; }
    }
}