using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class RequerimientoViewModel
    {
        public int ID { get; set; }
        public string Estado { get; set; }
        public string Solicitante { get; set; }
        public string TipoRequerimiento { get; set; }
        public string Prioridad { get; set; }
        public string Requerimiento { get; set; }
        public string Proyecto { get; set; }
        public string Aplicacion { get; set; }
        public string Opcion { get; set; }
        public string Hardware { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime F_Plazo { get; set; }
    }

}