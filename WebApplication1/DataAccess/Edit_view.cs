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
    
    public partial class Edit_view
    {
        public int Ingreso_requerimiento_id { get; set; }
        public Nullable<System.DateTime> f_asig { get; set; }
        public string Solicitante { get; set; }
        public string ejecutor { get; set; }
        public string Requerimiento { get; set; }
        public Nullable<int> Duracion_Hr { get; set; }
        public Nullable<System.DateTime> f_inicial { get; set; }
        public Nullable<System.DateTime> f_final { get; set; }
        public Nullable<int> cumplimiento_percent { get; set; }
        public string comentario_Req { get; set; }
        public string comentario_Rev { get; set; }
        public Nullable<bool> Publicado { get; set; }
    }
}