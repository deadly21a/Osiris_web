using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AsignadoController : Controller
    {
        // GET: Asignado
        public ActionResult RequerimientoAsignado()
        {
            return View();
        }


        public JsonResult ObtenerDatosEjecutor(string term)
        {
            try
            {
                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    var detEjecutor = osirisEntities.Ejecutor
                        .Where(deta => deta.TipoEjecutor.Contains(term))
                        .Select(deta => new{
                            id = deta.ID_Ejecutor,
                            text = deta.TipoEjecutor
                        })
                        .ToList();

                    return Json(new { success = true, items = detEjecutor }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);

            }
        }






                //public JsonResult ObtenerDatosEjecutor(int id_Ejecutor)
                //{
                //    try
                //    {

                //        using (OsirisEntities osirisEntities = new OsirisEntities())
                //        {
                //            if (id_Ejecutor != 0)
                //            {
                //                var detEjecutor = (from deta in osirisEntities.Ejecutor
                //                                   where deta.ID_Ejecutor == id_Ejecutor
                //                                   select new
                //                                   {
                //                                       id = deta.ID_Ejecutor,
                //                                       text = deta.TipoEjecutor
                //                                   }).ToList();
                //                return Json(new { success = true, items = detEjecutor }, JsonRequestBehavior.AllowGet);
                //            }
                //            else
                //            {
                //                var detEjecutor = (from deta in osirisEntities.Ejecutor

                //                                   select new
                //                                   {
                //                                       id = deta.ID_Ejecutor,
                //                                       text = deta.TipoEjecutor
                //                                   }).ToList();
                //                return Json(new { success = true, items = detEjecutor }, JsonRequestBehavior.AllowGet);
                //            }




                //        }


                //    }
                //    catch (Exception ex)
                //    {
                //        return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
                //    }
                //}



        public JsonResult ObtenerDatosPublicado(int id_Publicado)
        {
            try
            {

                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    if (id_Publicado != 0)
                    {
                        var detPublicado = (from deta in osirisEntities.Publicado
                                           where deta.ID_Publicado == id_Publicado
                                           select new
                                           {
                                               id = deta.ID_Publicado,
                                               text = deta.TipoPublicado
                                           }).ToList();
                        return Json(new { success = true, items = detPublicado }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var detPublicado = (from deta in osirisEntities.Publicado

                                            select new
                                           {
                                               id = deta.ID_Publicado,
                                               text = deta.TipoPublicado
                                           }).ToList();
                        return Json(new { success = true, items = detPublicado }, JsonRequestBehavior.AllowGet);
                    }




                }


            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error: {ex.Message}" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ConsultaRequerimiento(string ID_ingreso_requerimiento)
        {
            try
            {
                int IdRequerimiento = Int32.Parse(ID_ingreso_requerimiento);
                using (OsirisEntities db = new OsirisEntities())
                {
                    string updateQuery = "UPDATE ingreso_requerimiento SET ID_Estado = ID_Estado WHERE ID_ingreso_requerimiento = @IdRequerimiento";
                    db.Database.ExecuteSqlCommand(updateQuery, new SqlParameter("@IdRequerimiento", IdRequerimiento));

                    var model = db.RevisionRequerimiento.FirstOrDefault(r => r.ID_ingreso_requerimiento == IdRequerimiento);

                    return Json(new { datos = model }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "No se encontraron datos para el ID proporcionado",
                    errorDetails = ex.Message
                });
            }
        }



        [HttpPost]
        public JsonResult BtnEnviarDatos(AsignacionRequerimientoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (OsirisEntities db = new OsirisEntities())
                    {
                        RequerimientoAsignado nuevoRequerimiento = new RequerimientoAsignado
                        {
                            ID_Estado = model.ID_Estado,
                            ID_ingreso_requerimiento = model.ID_ingreso_requerimiento,
                            ID_Solicitante = model.ID_Solicitante,
                            Requerimiento = model.Requerimiento,
                            F_revision = model.F_revision,
                            Comentario_rev = model.Comentario_rev,
                            Duracion_Hr = model.Duracion_Hr,
                            ID_Ejecutor = model.ID_Ejecutor,
                            F_inicio = model.F_inicio,
                            F_fin = model.F_fin,
                            ID_Publicado = model.ID_Publicado,
                            Cumplimiento = model.Cumplimiento,
                            Comentario_asig = model.Comentario_asig
                        };

                        db.RequerimientoAsignado.Add(nuevoRequerimiento);
                        db.SaveChanges();
                    }

                    return Json(new { success = true, message = "Requerimiento asignado exitosamente." });
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