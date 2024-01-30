using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RevisionController : Controller
    {
        //datos de Datatable 
        public string draw = "";
        public string start = "";
        public string length = "";
        public string sortColumn = "";
        public string sortColumnDir = "";
        public string searchvalue = "";
        public int pageSize, skip, recordsTotal;

        public ActionResult RevisionRequerimiento()
        {
            return View();
        }
        private OsirisEntities db = new OsirisEntities();

        public ActionResult Index()
        {
            return View(db.VistaRevisionRequerimiento.ToList());
        }

        public ActionResult Index1()
        {

            // var datareturn = db.VistaRevisionRequerimiento.ToList()
            // return View(datareturn);

            return View();
        }


        public JsonResult Json()
        {
            List<VistaRevisionRequerimientoViewModel> revisiones = new List<VistaRevisionRequerimientoViewModel>();

            string connectionString = ConfigurationManager.ConnectionStrings["Osiris"].ConnectionString;
            string query = @"
               SELECT
                    RR.ID_RevisionRequerimiento,
                    E.TipoEstado AS Estado,
                    S.Nombres AS Solicitante,
                    TR.TipoRequerimiento AS TipoRequerimiento,
                    P.TipoPrioridad AS Prioridad,
                    RR.Requerimiento,
                    PR.TipoMantenimiento AS Proyecto,
                    A.TipoAplicacion AS Aplicacion,
                    RR.Opcion,
                    H.TipoHardware AS Hardware,
                    UR.TipoUsuario AS UsuarioRevision,
                    RR.Comentario,
                    RR.fecha_ingreso,
                    RR.F_Plazo,
                    RR.F_revision,
                    RR.Comentario_rev,
                    RR.Duracion_Hr,
                    RR.ID_ingreso_requerimiento, 
                    RR.ID_Estado,
                    RR.ID_Solicitante,
                    RR.ID_Tipo_requerimiento,
                    RR.ID_Prioridad,
                    RR.ID_Proyecto,
                    RR.ID_Aplicacion,
                    RR.ID_Hardware,
                    RR.ID_Usuario
                FROM
                    RevisionRequerimiento RR
                    INNER JOIN Estado E ON RR.ID_Estado = E.ID_Estado
                    INNER JOIN Solicitante S ON RR.ID_Solicitante = S.ID_Solicitante
                    INNER JOIN Tipo_requerimiento TR ON RR.ID_Tipo_requerimiento = TR.ID_Tipo_requerimiento
                    INNER JOIN Prioridad P ON RR.ID_Prioridad = P.ID_Prioridad
                    INNER JOIN Proyecto PR ON RR.ID_Proyecto = PR.ID_Proyecto
                    INNER JOIN Aplicacion A ON RR.ID_Aplicacion = A.ID_Aplicacion
                    LEFT JOIN Hardware H ON RR.ID_Hardware = H.ID_Hardware
                    LEFT JOIN UsuarioRevision UR ON RR.ID_Usuario = UR.ID_Usuario
            ";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        VistaRevisionRequerimientoViewModel revision = new VistaRevisionRequerimientoViewModel
                        {
                            ID_ingreso_requerimiento = reader["ID_ingreso_requerimiento"] != DBNull.Value ? Convert.ToInt32(reader["ID_ingreso_requerimiento"]) : 0,
                            Estado = reader["Estado"] != DBNull.Value ? Convert.ToInt32(reader["Estado"]) : 0,
                            fecha_ingreso = reader["fecha_ingreso"] != DBNull.Value ? Convert.ToDateTime(reader["fecha_ingreso"]) : DateTime.MinValue,
                            Solicitante = reader["Solicitante"] != DBNull.Value ? Convert.ToInt32(reader["Solicitante"]) : 0,
                            Aplicacion = reader["Aplicacion"] != DBNull.Value ? Convert.ToInt32(reader["Aplicacion"]) : 0,
                            Hardware = reader["Hardware"] != DBNull.Value ? Convert.ToInt32(reader["Hardware"]) : 0,
                            Prioridad = reader["Prioridad"] != DBNull.Value ? Convert.ToInt32(reader["Prioridad"]) : 0,
                            Proyecto = reader["Proyecto"] != DBNull.Value ? Convert.ToInt32(reader["Proyecto"]) : 0,
                            Tipo_requerimiento = reader["Tipo_requerimiento"] != DBNull.Value ? Convert.ToInt32(reader["Tipo_requerimiento"]) : 0,
                            Requerimiento = reader["Requerimiento"] != DBNull.Value ? reader["Requerimiento"].ToString() : string.Empty,
                            Opcion = reader["Opcion"] != DBNull.Value ? reader["Opcion"].ToString() : string.Empty,
                            Comentario = reader["Comentario"] != DBNull.Value ? reader["Comentario"].ToString() : string.Empty,
                            F_Plazo = reader["F_Plazo"] != DBNull.Value ? Convert.ToDateTime(reader["F_Plazo"]) : DateTime.MinValue,
                            Comentario_rev = reader["Comentario_rev"] != DBNull.Value ? reader["Comentario_rev"].ToString() : string.Empty,
                            Duracion_Hr = reader["Duracion_Hr"] != DBNull.Value ? Convert.ToDecimal(reader["Duracion_Hr"]) : 0,
                            F_revision = reader["F_revision"] != DBNull.Value ? Convert.ToDateTime(reader["F_revision"]) : DateTime.MinValue,
                            UsuarioRevision = reader["UsuarioRevision"] != DBNull.Value ? Convert.ToInt32(reader["UsuarioRevision"]) : 0
                        };

                        revisiones.Add(revision);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de formato al leer datos: " + ex.Message);
            }


            return Json(new
            {
                success = true,
                message = "",
                ListaRequerimiento = revisiones.ToList()
            }, JsonRequestBehavior.AllowGet);

        }





        // GET: RevisionRequerimientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevisionRequerimiento revisionRequerimiento = db.RevisionRequerimiento.Find(id);
            if (revisionRequerimiento == null)
            {
                return HttpNotFound();
            }
            return View(revisionRequerimiento);
        }

        // GET: RevisionRequerimientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RevisionRequerimientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RevisionRequerimiento,ID_ingreso_requerimiento,ID_Estado,ID_Solicitante,ID_Tipo_requerimiento,ID_Prioridad,Requerimiento,ID_Proyecto,ID_Aplicacion,Opcion,ID_Hardware,Comentario,fecha_ingreso,F_Plazo,F_revision,Comentario_rev,Duracion_Hr,ID_Usuario")] RevisionRequerimiento revisionRequerimiento)
        {
            if (ModelState.IsValid)
            {
                db.RevisionRequerimiento.Add(revisionRequerimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return Json(revisionRequerimiento);
        }

        // GET: RevisionRequerimientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevisionRequerimiento revisionRequerimiento = db.RevisionRequerimiento.Find(id);
            if (revisionRequerimiento == null)
            {
                return HttpNotFound();
            }
            return View(revisionRequerimiento);
        }

        // POST: RevisionRequerimientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RevisionRequerimiento,ID_ingreso_requerimiento,ID_Estado,ID_Solicitante,ID_Tipo_requerimiento,ID_Prioridad,Requerimiento,ID_Proyecto,ID_Aplicacion,Opcion,ID_Hardware,Comentario,fecha_ingreso,F_Plazo,F_revision,Comentario_rev,Duracion_Hr,ID_Usuario")] RevisionRequerimiento revisionRequerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(revisionRequerimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(revisionRequerimiento);
        }

        // GET: RevisionRequerimientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RevisionRequerimiento revisionRequerimiento = db.RevisionRequerimiento.Find(id);
            if (revisionRequerimiento == null)
            {
                return HttpNotFound();
            }
            return View(revisionRequerimiento);
        }

        // POST: RevisionRequerimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RevisionRequerimiento revisionRequerimiento = db.RevisionRequerimiento.Find(id);
            db.RevisionRequerimiento.Remove(revisionRequerimiento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


       
        public JsonResult ObtenerDatosUsuario(int id_Usuario)
        {
            try
            {

                using (OsirisEntities osirisEntities = new OsirisEntities())
                {
                    if (id_Usuario != 0)
                    {
                        var detUusuario = (from deta in osirisEntities.UsuarioRevision
                                           where deta.ID_Usuario == id_Usuario
                                           select new
                                           {
                                               id = deta.ID_Usuario,
                                               text = deta.TipoUsuario
                                           }).ToList();
                        return Json(new { success = true, items = detUusuario }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var detUusuario = (from deta in osirisEntities.UsuarioRevision

                                           select new
                                           {
                                               id = deta.ID_Usuario,
                                               text = deta.TipoUsuario
                                           }).ToList();
                        return Json(new { success = true, items = detUusuario }, JsonRequestBehavior.AllowGet);
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

            ingreso_requerimiento model = new ingreso_requerimiento();
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
                            datos.ID_Estado = 2;
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

                    model = db.ingreso_requerimiento.FirstOrDefault(r => r.ID_ingreso_requerimiento == IdRequerimiento);
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


        [HttpPost]
        public JsonResult BtnEnviarDatos(RevisionRequerimientoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (OsirisEntities db = new OsirisEntities())
                    {
                        string query = @"
                    INSERT INTO RevisionRequerimiento (ID_Estado, ID_ingreso_requerimiento, ID_Solicitante, ID_Tipo_requerimiento, ID_Prioridad, Requerimiento, ID_Proyecto, ID_Aplicacion, Opcion, ID_Hardware, Comentario, fecha_ingreso, F_Plazo, F_revision, Comentario_rev, Duracion_Hr, ID_Usuario)
                    VALUES (@ID_Estado, @ID_ingreso_requerimiento, @ID_Solicitante, @ID_Tipo_requerimiento, @ID_Prioridad, @Requerimiento, @ID_Proyecto, @ID_Aplicacion, @Opcion, @ID_Hardware, @Comentario, @fecha_ingreso, @F_Plazo, @F_revision, @Comentario_rev, @Duracion_Hr, @ID_Usuario)";

                        db.Database.ExecuteSqlCommand(query,
                            new SqlParameter("@ID_Estado", model.ID_Estado),
                            new SqlParameter("@ID_ingreso_requerimiento", model.ID_ingreso_requerimiento),
                            new SqlParameter("@ID_Solicitante", model.ID_Solicitante),
                            new SqlParameter("@ID_Tipo_requerimiento", model.ID_Tipo_requerimiento),
                            new SqlParameter("@ID_Prioridad", model.ID_Prioridad),
                            new SqlParameter("@Requerimiento", model.Requerimiento),
                            new SqlParameter("@ID_Proyecto", model.ID_Proyecto),
                            new SqlParameter("@ID_Aplicacion", model.ID_Aplicacion),
                            new SqlParameter("@Opcion", model.Opcion),
                            new SqlParameter("@ID_Hardware", model.ID_Hardware),
                            new SqlParameter("@Comentario", model.Comentario),
                            new SqlParameter("@fecha_ingreso", model.fecha_ingreso),
                            new SqlParameter("@F_Plazo", model.F_Plazo),
                            new SqlParameter("@F_revision", model.F_revision),
                            new SqlParameter("@Comentario_rev", model.Comentario_rev),
                            new SqlParameter("@Duracion_Hr", model.Duracion_Hr),
                            new SqlParameter("@ID_Usuario", model.ID_Usuario));

                        return Json(new { success = true, message = "Requerimiento Revisado exitosamente." });
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


        //[HttpPost]
        //public JsonResult BtnEnviarDatos(RevisionRequerimientoViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            using (OsirisEntities db = new OsirisEntities())
        //                {
        //                var datos = new RevisionRequerimiento
        //                {
        //                    ID_Estado = model.ID_Estado,
        //                    ID_ingreso_requerimiento = model.ID_ingreso_requerimiento,
        //                    ID_Solicitante = model.ID_Solicitante,
        //                    ID_Tipo_requerimiento = model.ID_Tipo_requerimiento,
        //                    ID_Prioridad = model.ID_Prioridad,
        //                    Requerimiento = model.Requerimiento,
        //                    ID_Proyecto = model.ID_Proyecto,
        //                    ID_Aplicacion = model.ID_Aplicacion,
        //                    Opcion = model.Opcion,
        //                    ID_Hardware = model.ID_Hardware,
        //                    Comentario = model.Comentario,
        //                    fecha_ingreso = model.fecha_ingreso,
        //                    F_Plazo = model.F_Plazo,
        //                    F_revision = model.F_revision,
        //                    Comentario_rev = model.Comentario_rev,
        //                    Duracion_Hr = model.Duracion_Hr,
        //                    ID_Usuario = model.ID_Usuario
        //                };

        //                db.RevisionRequerimiento.Add(datos);
        //                db.SaveChanges();
        //            }


        //            return Json(new { success = true, message = "Requerimiento Revisado exitosamente." });
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
