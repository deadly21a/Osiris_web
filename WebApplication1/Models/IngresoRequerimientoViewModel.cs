using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class IngresoRequerimientoViewModel
    {
        

        public DateTime fecha_ingreso { get; set; }
        public int ID_Estado { get; set; }
        public int ID_Solicitante { get; set; }
        public int ID_Tipo_requerimiento { get; set; }
        public int ID_Prioridad { get; set; }
        public string Requerimiento { get; set; }
        public int ID_Proyecto { get; set; }
        public int? ID_Aplicacion { get; set; }
        public string Opcion { get; set; }
        public int? ID_Hardware { get; set; }
        public string Comentario { get; set; }
        public DateTime F_Plazo { get; set; }


    }
}