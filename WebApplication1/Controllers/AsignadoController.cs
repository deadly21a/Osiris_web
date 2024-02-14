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

        public JsonResult ConsultaRequerimiento(string ID_ingreso_requerimiento)
        {

            VistaRevisionRequerimiento model = new VistaRevisionRequerimiento();
            int IdRequerimiento = Int32.Parse(ID_ingreso_requerimiento.ToString());
            using (OsirisEntities db = new OsirisEntities())
            {
                try
                {
                    using (var dbContextTransaction = db.Database.BeginTransaction())
                    {


                        var datos = db.ingreso_requerimiento.FirstOrDefault(r => r.ID_ingreso_requerimiento == IdRequerimiento);

                        if (datos != null)
                        {

                            //model.ID_ingreso_requerimiento = datos.ID_ingreso_requerimiento;
                            //model.ID_Estado = (int)datos.ID_Estado;
                            //model.ID_Solicitante = (int)datos.ID_Solicitante;
                            //model.ID_Tipo_requerimiento = (int)datos.ID_Tipo_requerimiento;
                            //model.ID_Prioridad = (int)datos.ID_Prioridad;
                            //model.Requerimiento = datos.Requerimiento;
                            //model.ID_Proyecto = (int)datos.ID_Proyecto;
                            //model.ID_Aplicacion = (int)datos.ID_Aplicacion;
                            //model.Opcion = datos.Opcion;
                            //model.ID_Hardware = (int)datos.ID_Hardware;
                            //model.Comentario = datos.Comentario;
                            //model.fecha_ingreso = (DateTime)datos.fecha_ingreso;
                            //model.F_Plazo = (DateTime)datos.F_Plazo;
                            //model.ID_Estado = 2;
                            datos.ID_Estado = 3;
                            // Cambiar el estado a "Revisado"
                            // datos.ID_Estado = ObtenerIdEstadoRevisado(db);
                            //db.ingreso_requerimiento.Attach(datos);
                            db.Entry(datos).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();


                            dbContextTransaction.Commit();
                            dbContextTransaction.Dispose();

                            // Confirmar la transacción

                            // return View("RevisionRequerimiento", model);
                            //return Json(new { success = false, message = "No se encontraron datos para el ID proporcionado", errorDetails = "" });
                        }


                    }

                    model = db.VistaRevisionRequerimiento.FirstOrDefault(r => r.ID_ingreso_requerimiento == IdRequerimiento);
                    db.Dispose();
                    return Json(new { datos = model }, JsonRequestBehavior.AllowGet);

                    // return Json(new { success = false, message = "No se encontraron datos para el ID proporcionado", errorDetails = ""});
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


        }


        //[HttpPost]
        //public JsonResult ConsultaRequerimiento(string ID_ingreso_requerimiento)
        //{
        //    try
        //    {
        //        int IdRequerimiento = Int32.Parse(ID_ingreso_requerimiento);
        //        using (OsirisEntities db = new OsirisEntities())
        //        {
        //            string updateQuery = "UPDATE VistaIngresoRequerimiento SET ID_Estado = ID_Estado WHERE ID_ingreso_requerimiento = @IdRequerimiento";
        //            db.Database.ExecuteSqlCommand(updateQuery, new SqlParameter("@IdRequerimiento", IdRequerimiento));

        //            var model = db.VistaRevisionRequerimiento.FirstOrDefault(r => r.ID_ingreso_requerimiento == IdRequerimiento);

        //            return Json(new { datos = model }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            message = "No se encontraron datos para el ID proporcionado",
        //            errorDetails = ex.Message
        //        });
        //    }
        //}



        [HttpPost]
        public JsonResult BtnEnviarDatos(AsignacionRequerimientoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (OsirisEntities db = new OsirisEntities())
                    {
                        string query = @"
                    INSERT INTO RequerimientoAsignado (ID_Estado, ID_ingreso_requerimiento, ID_Solicitante, Requerimiento, F_revision, Comentario_rev, Duracion_Hr, ID_Ejecutor, F_inicio, F_fin, ID_Publicado, Cumplimiento, Comentario_Asig)
                    VALUES(@ID_Estado, @ID_ingreso_requerimiento, @ID_Solicitante, @Requerimiento, @F_revision, @Comentario_rev, @Duracion_Hr, @ID_Ejecutor, @F_inicio, @F_fin, @ID_Publicado, @Cumplimiento, @Comentario_Asig)";
                        db.Database.ExecuteSqlCommand(query,
                            new SqlParameter("@ID_Estado", model.ID_Estado),
                            new SqlParameter("@ID_ingreso_requerimiento", model.ID_ingreso_requerimiento),
                            new SqlParameter("@ID_Solicitante", model.ID_Solicitante),
                            new SqlParameter("@Requerimiento", model.Requerimiento),
                            new SqlParameter("@F_revision", model.F_revision),
                            new SqlParameter("@Comentario_rev", model.Comentario_rev),
                            new SqlParameter("@Duracion_Hr", model.Duracion_Hr),
                            new SqlParameter("@ID_Ejecutor", model.ID_Ejecutor),
                            new SqlParameter("@F_inicio", model.F_inicio),
                            new SqlParameter("@F_fin", model.F_fin),
                            new SqlParameter("@ID_Publicado", model.ID_Publicado),
                            new SqlParameter("@Cumplimiento", model.Cumplimiento),
                            new SqlParameter("@Comentario_asig", model.Comentario_asig));

                        return Json(new { success = true, message = "Requerimiento Asignado Correctamente" });
                    }
                    
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