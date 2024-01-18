﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RequerimientoController : Controller
    {
        // GET: Requerimiento
        public ActionResult IngresoRequerimiento()
        {
            return View();
        }
        


        public JsonResult ObtenerDatosAplicacion(int id_Aplicacion)
        {
            try
            {

                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    if(id_Aplicacion != 0)
                    {
                        var detAplicacion = (from deta in osirisEntities.Aplicacion
                                            where deta.ID_Aplicacion == id_Aplicacion
                                            select new
                                            {
                                                id = deta.ID_Aplicacion,
                                                text = deta.TipoAplicacion
                                            }).ToList();
                        return Json(new { success = true, items = detAplicacion }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var detAplicacion = (from deta in osirisEntities.Aplicacion
                                            
                                            select new
                                            {
                                                id = deta.ID_Aplicacion,
                                                text = deta.TipoAplicacion
                                            }).ToList();
                        return Json(new { success = true, items = detAplicacion }, JsonRequestBehavior.AllowGet);
                    }



                    
                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerDatosSolicitante(int id_Solicitante)
        {
            try
            {

                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    if (id_Solicitante != 0)
                    {
                        var detSolicitante = (from deta in osirisEntities.Solicitante
                                             where deta.ID_Solicitante == id_Solicitante
                                             select new
                                             {
                                                 id = deta.ID_Solicitante,
                                                 text = deta.Nombres
                                             }).ToList();
                        return Json(new { success = true, items = detSolicitante }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var detSolicitante = (from deta in osirisEntities.Solicitante

                                             select new
                                             {
                                                 id = deta.ID_Solicitante,
                                                 text = deta.Nombres
                                             }).ToList();
                        return Json(new { success = true, items = detSolicitante }, JsonRequestBehavior.AllowGet);
                    }




                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerDatosEstado(int id_Estado)
        {
            try
            {

                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    if (id_Estado != 0)
                    {
                        var detEstado = (from deta in osirisEntities.Estado
                                         where deta.ID_Estado == id_Estado
                                         select new
                                         {
                                             id = deta.ID_Estado,
                                             text = deta.TipoEstado
                                         }).ToList();
                        return Json(new { success = true, items = detEstado }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var detEstado = (from deta in osirisEntities.Estado

                                         select new
                                         {
                                             id = deta.ID_Estado,
                                             text = deta.TipoEstado
                                         }).ToList();
                        return Json(new { success = true, items = detEstado }, JsonRequestBehavior.AllowGet);
                    }




                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerDatosTipoRequerimiento(int id_Tipo_requerimiento)
        {
            try
            {

                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    if (id_Tipo_requerimiento != 0)
                    {
                        var detTipoRequerimiento = (from deta in osirisEntities.Tipo_requerimiento
                                         where deta.ID_Tipo_requerimiento == id_Tipo_requerimiento
                                                    select new
                                         {
                                             id = deta.ID_Tipo_requerimiento,
                                             text = deta.TipoRequerimiento
                                         }).ToList();
                        return Json(new { success = true, items = detTipoRequerimiento }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var detTipoRequerimiento = (from deta in osirisEntities.Tipo_requerimiento

                                                    select new
                                         {
                                             id = deta.ID_Tipo_requerimiento,
                                             text = deta.TipoRequerimiento
                                                    }).ToList();
                        return Json(new { success = true, items = detTipoRequerimiento }, JsonRequestBehavior.AllowGet);
                    }




                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerDatosPrioridad(int id_Prioridad)
        {
            try
            {

                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    if (id_Prioridad != 0)
                    {
                        var detPrioridad = (from deta in osirisEntities.Prioridad
                                         where deta.ID_Prioridad == id_Prioridad
                                         select new
                                         {
                                             id = deta.ID_Prioridad,
                                             text = deta.TipoPrioridad
                                         }).ToList();
                        return Json(new { success = true, items = detPrioridad }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var detPrioridad = (from deta in osirisEntities.Prioridad

                                         select new
                                         {
                                             id = deta.ID_Prioridad,
                                             text = deta.TipoPrioridad
                                         }).ToList();
                        return Json(new { success = true, items = detPrioridad }, JsonRequestBehavior.AllowGet);
                    }




                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerDatosProyecto(int id_Proyecto)
        {
            try
            {

                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    if (id_Proyecto != 0)
                    {
                        var detProyecto = (from deta in osirisEntities.Proyecto
                                            where deta.ID_Proyecto == id_Proyecto
                                            select new
                                            {
                                                id = deta.ID_Proyecto,
                                                text = deta.TipoMantenimiento
                                            }).ToList();
                        return Json(new { success = true, items = detProyecto }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var detProyecto = (from deta in osirisEntities.Proyecto

                                           select new
                                            {
                                                id = deta.ID_Proyecto,
                                                text = deta.TipoMantenimiento
                                           }).ToList();
                        return Json(new { success = true, items = detProyecto }, JsonRequestBehavior.AllowGet);
                    }




                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult ObtenerDatosHardware(int id_Hardware)
        {
            try
            {

                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    if (id_Hardware != 0)
                    {
                        var detHardware = (from deta in osirisEntities.Hardware
                                           where deta.ID_Hardware == id_Hardware
                                           select new
                                           {
                                               id = deta.ID_Hardware,
                                               text = deta.TipoHardware
                                           }).ToList();
                        return Json(new { success = true, items = detHardware }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var detHardware = (from deta in osirisEntities.Hardware

                                           select new
                                           {
                                               id = deta.ID_Hardware,
                                               text = deta.TipoHardware
                                           }).ToList();
                        return Json(new { success = true, items = detHardware }, JsonRequestBehavior.AllowGet);
                    }




                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult BtnEnviarDatos(IngresoRequerimientoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (OsirisEntities db = new OsirisEntities())
                    {
                        var datos = new ingreso_requerimiento
                        {
                            ID_Estado = model.ID_Estado,
                            ID_Solicitante = model.ID_Solicitante,
                            ID_Tipo_requerimiento = model.ID_Tipo_requerimiento,
                            ID_Prioridad = model.ID_Prioridad,
                            Requerimiento = model.Requerimiento,
                            ID_Proyecto = model.ID_Proyecto,
                            ID_Aplicacion = model.ID_Aplicacion,  
                            Opcion = model.Opcion,
                            ID_Hardware = model.ID_Hardware,
                            Comentario = model.Comentario,
                            fecha_ingreso = DateTime.Now,
                            F_Plazo = model.F_Plazo

                        };

                        db.ingreso_requerimiento.Add(datos);
                        db.SaveChanges();
                    }
                    

                    return Json(new { success = true, message = "Requerimiento guardado exitosamente." });
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    return Json(new { success = false, error = errors });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al guardar el requerimiento.", errorDetails = ex.Message });
            }
        }

    }
}