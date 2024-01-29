using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RevisionController : Controller
    {
        public ActionResult RevisionRequerimiento()
        {
            return View();
        }

        public ActionResult ObtenerDatos(RevisionRequerimientoViewModel model)
        {
            return View(model);
            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        using (OsirisEntities db = new OsirisEntities())
            //        {
            //            var datos = new ingreso_requerimiento
            //            {
            //                ID = model.ID,
            //                // fecha_ingreso = model.fecha_ingreso,
            //                Estado = model.Estado,
            //                Solicitante = model.Solicitante,
            //                Tipo_requerimiento = model.Tipo_requerimiento,
            //                prioridad = model.prioridad,
            //                Requerimiento = model.Requerimiento,
            //                Proyecto = model.Proyecto,
            //                Aplicacion = model.Aplicacion,
            //                Opcion = model.Opcion,
            //                Hardware = model.Hardware,
            //                Comentario = model.Comentario,
            //                F_Plazo = model.F_Plazo

            //            };

            //            db.ingreso_requerimiento.Add(datos);
            //            db.SaveChanges();
            //        }

            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
                
        }


        //                };

        //                db.ingreso_requerimiento.Add(datos);
        //                db.SaveChanges();
        //            }


        //            return Json(new { success = true, message = "Requerimiento guardado exitosamente." });
        //        }
        //        else
        //        {
        //            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
        //            return Json(new { success = false, error = errors });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, message = "Error al guardar el requerimiento.", errorDetails = ex.Message });
        //    }
        //}

    }
}