using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class VistaRequerimientoAsignadoViewModel
    {
        public int ID_ingreso_requerimiento { get; set; }
        public DateTime F_inicio { get; set; }
        public int Estado { get; set; }
        public int Solicitante { get; set; }
        public string Requerimiento { get; set; }
        public string Comentario { get; set; }
        public DateTime F_revision { get; set; }
        public string Comentario_rev { get; set; }
        public decimal Duracion_Hr { get; set; }
        public int Ejecutor { get; set; }
        public int Publicado {  get; set; }
        public string Comentario_asig {  get; set; }
        public DateTime F_fin {  get; set; }
    }
}