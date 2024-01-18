    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    namespace WebApplication1.Models
    {
        public class RevisionRequerimientoViewModel
        {
        public List<RevisionRequerimientoViewModel> Revision { get; set; }
        public int ID { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public string Estado { get; set; }
        public string Solicitante { get; set; }
        public string Tipo_requerimiento { get; set; }
        public int prioridad { get; set; }
        public string Requerimiento { get; set; }
        public string Proyecto { get; set; }
        public string Aplicacion { get; set; }
        public string Opcion { get; set; }
        public string Hardware { get; set; }
        public string Comentario { get; set; }
        public DateTime F_Plazo { get; set; }
        public string ComentarioRev { get; set; }
        public string Duracion { get; set; }
        public string Ejecutor { get; set; }

        }
    }
