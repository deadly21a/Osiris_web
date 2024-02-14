using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AsignacionRequerimientoViewModel
    {
        public int ID_ingreso_requerimiento { get; set; }
        
        public int ID_Solicitante { get; set; }
        
        public string Requerimiento { get; set; }
        
        public DateTime F_revision { get; set; }
        public string Comentario_rev { get; set; }
        public decimal Duracion_Hr { get; set; }
        public int ID_Ejecutor { get; set; }
        public DateTime F_inicio { get; set; }
        public DateTime F_fin {  get; set; }
        public int? ID_Publicado { get; set; }
        public  decimal Cumplimiento { get; set; }
        public string Comentario_asig { get; set; }
        public int ID_Estado { get; set; }


    }
}