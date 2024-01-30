using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class KanbanController : Controller
    {
        private OsirisEntities db = new OsirisEntities();

        public PartialViewResult Kanban1(int id)
        {

            string partialurl = "/Views/Partial/Kanban/_DetKanban.cshtml";
            RequerimientoViewModel objRequerimiento = new RequerimientoViewModel();
            var requerimientos = (from deta in db.VistaIngresoRequerimiento
                                  where deta.ID_ingreso_requerimiento == id
                                  select deta).ToList();

            RequerimientoViewModel requerimientoViewModel = new RequerimientoViewModel();

            foreach (var requerimiento in requerimientos)
            {
                requerimientoViewModel = new RequerimientoViewModel
                {
                    ID = requerimiento.ID_ingreso_requerimiento,
                    Solicitante = requerimiento.Solicitante,
                    Requerimiento = requerimiento.Requerimiento,
                    Proyecto = requerimiento.Proyecto,
                    Prioridad = requerimiento.Prioridad,
                    FechaIngreso = (DateTime)requerimiento.fecha_ingreso,
                    F_Plazo = (DateTime)requerimiento.F_Plazo,
                    TipoRequerimiento = requerimiento.TipoRequerimiento,
                    Aplicacion = requerimiento.Aplicacion,
                    Opcion = requerimiento.Opcion,
                    Hardware = requerimiento.Hardware,
                    Comentario = requerimiento.Comentario

                };

                
            };

            return PartialView(partialurl, requerimientoViewModel);

        }

        public ActionResult Kanban()

        {
            var requerimientos = db.VistaIngresoRequerimiento.ToList();
            var kanbanData = new Dictionary<string, List<RequerimientoViewModel>>();

            kanbanData.Add("Ingresado", new List<RequerimientoViewModel>());
            kanbanData.Add("Revisado", new List<RequerimientoViewModel>());
            kanbanData.Add("Asignado", new List<RequerimientoViewModel>());
            kanbanData.Add("Finalizado", new List<RequerimientoViewModel>());
            kanbanData.Add("Anulado", new List<RequerimientoViewModel>());

            foreach (var requerimiento in requerimientos)
            {
                var requerimientoViewModel = new RequerimientoViewModel
                {
                    ID = requerimiento.ID_ingreso_requerimiento,
                    Solicitante = requerimiento.Solicitante,
                    Requerimiento = requerimiento.Requerimiento,
                    Proyecto = requerimiento.Proyecto,
                    Prioridad = requerimiento.Prioridad,
                    FechaIngreso = (DateTime)requerimiento.fecha_ingreso,
                    F_Plazo = (DateTime)requerimiento.F_Plazo,
                    TipoRequerimiento = requerimiento.TipoRequerimiento,
                    Aplicacion = requerimiento.Aplicacion,
                    Opcion = requerimiento.Opcion,
                    Hardware = requerimiento.Hardware,
                    Comentario = requerimiento.Comentario

                };

                switch (requerimiento.Estado)
                {
                    case "Ingresado":
                        kanbanData["Ingresado"].Add(requerimientoViewModel);
                        break;
                    case "Revisado":
                        kanbanData["Revisado"].Add(requerimientoViewModel);
                        break;
                    case "Asignado":
                        kanbanData["Asignado"].Add(requerimientoViewModel);
                        break;
                    case "Finalizado":
                        kanbanData["Finalizado"].Add(requerimientoViewModel);
                        break;
                    case "Anulado":
                        kanbanData["Anulado"].Add(requerimientoViewModel);
                        break;
                    default:
                        
                        break;
                }
            }

            return View(kanbanData);
        }
    }
}