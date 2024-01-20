using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class VistaIngresoRequerimientoViewModels
    {
        public DateTime fecha_ingreso { get; set; }
        public int Estado { get; set; }
        public int Solicitante { get; set; }
        public int TipoRequerimiento { get; set; }
        public int Prioridad { get; set; }
        public string Requerimiento { get; set; }
        public int Proyecto { get; set; }
        public int Aplicacion { get; set; }
        public string Opcion { get; set; }
        public int Hardware { get; set; }
        public string Comentario { get; set; }
        public DateTime F_Plazo { get; set; }
    }
}