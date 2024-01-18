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
    public class VistaIngresoRequerimientoesController : Controller
    {
        private OsirisEntities db = new OsirisEntities();

        // GET: VistaIngresoRequerimientoes
        public ActionResult Index()
        {
            return View(db.VistaIngresoRequerimiento.ToList());
        }

        // GET: VistaIngresoRequerimientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VistaIngresoRequerimiento vistaIngresoRequerimiento = db.VistaIngresoRequerimiento.Find(id);
            if (vistaIngresoRequerimiento == null)
            {
                return HttpNotFound();
            }
            return View(vistaIngresoRequerimiento);
        }

        // GET: VistaIngresoRequerimientoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VistaIngresoRequerimientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ingreso_requerimiento,Estado,Solicitante,TipoRequerimiento,Prioridad,Requerimiento,Proyecto,Aplicacion,Opcion,Hardware,Comentario,fecha_ingreso,F_Plazo")] VistaIngresoRequerimiento vistaIngresoRequerimiento)
        {
            if (ModelState.IsValid)
            {
                db.VistaIngresoRequerimiento.Add(vistaIngresoRequerimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vistaIngresoRequerimiento);
        }

        // GET: VistaIngresoRequerimientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VistaIngresoRequerimiento vistaIngresoRequerimiento = db.VistaIngresoRequerimiento.Find(id);
            if (vistaIngresoRequerimiento == null)
            {
                return HttpNotFound();
            }
            return View(vistaIngresoRequerimiento);
        }

        // POST: VistaIngresoRequerimientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ingreso_requerimiento,Estado,Solicitante,TipoRequerimiento,Prioridad,Requerimiento,Proyecto,Aplicacion,Opcion,Hardware,Comentario,fecha_ingreso,F_Plazo")] VistaIngresoRequerimiento vistaIngresoRequerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vistaIngresoRequerimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vistaIngresoRequerimiento);
        }

        // GET: VistaIngresoRequerimientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VistaIngresoRequerimiento vistaIngresoRequerimiento = db.VistaIngresoRequerimiento.Find(id);
            if (vistaIngresoRequerimiento == null)
            {
                return HttpNotFound();
            }
            return View(vistaIngresoRequerimiento);
        }

        // POST: VistaIngresoRequerimientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VistaIngresoRequerimiento vistaIngresoRequerimiento = db.VistaIngresoRequerimiento.Find(id);
            db.VistaIngresoRequerimiento.Remove(vistaIngresoRequerimiento);
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
