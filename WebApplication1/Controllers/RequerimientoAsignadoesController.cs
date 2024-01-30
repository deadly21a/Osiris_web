using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;

namespace WebApplication1.Controllers
{
    public class RequerimientoAsignadoesController : Controller
    {
        private OsirisEntities db = new OsirisEntities();

        // GET: RequerimientoAsignadoes
        public ActionResult Index()
        {
            return View(db.VistaRequerimientoAsignado.ToList());
        }

        // GET: RequerimientoAsignadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequerimientoAsignado requerimientoAsignado = db.RequerimientoAsignado.Find(id);
            if (requerimientoAsignado == null)
            {
                return HttpNotFound();
            }
            return View(requerimientoAsignado);
        }

        // GET: RequerimientoAsignadoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequerimientoAsignadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_RequerimientoAsignado,ID_ingreso_requerimiento,ID_Solicitante,Requerimiento,F_revision,Comentario_rev,Duracion_Hr,ID_Ejecutor,Comentario_asig,Cumplimiento,F_inicio,F_fin,ID_Publicado,ID_Estado")] RequerimientoAsignado requerimientoAsignado)
        {
            if (ModelState.IsValid)
            {
                db.RequerimientoAsignado.Add(requerimientoAsignado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(requerimientoAsignado);
        }

        // GET: RequerimientoAsignadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequerimientoAsignado requerimientoAsignado = db.RequerimientoAsignado.Find(id);
            if (requerimientoAsignado == null)
            {
                return HttpNotFound();
            }
            return View(requerimientoAsignado);
        }

        // POST: RequerimientoAsignadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_RequerimientoAsignado,ID_ingreso_requerimiento,ID_Solicitante,Requerimiento,F_revision,Comentario_rev,Duracion_Hr,ID_Ejecutor,Comentario_asig,Cumplimiento,F_inicio,F_fin,ID_Publicado,ID_Estado")] RequerimientoAsignado requerimientoAsignado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(requerimientoAsignado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(requerimientoAsignado);
        }

        // GET: RequerimientoAsignadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RequerimientoAsignado requerimientoAsignado = db.RequerimientoAsignado.Find(id);
            if (requerimientoAsignado == null)
            {
                return HttpNotFound();
            }
            return View(requerimientoAsignado);
        }

        // POST: RequerimientoAsignadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RequerimientoAsignado requerimientoAsignado = db.RequerimientoAsignado.Find(id);
            db.RequerimientoAsignado.Remove(requerimientoAsignado);
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
    }
}
