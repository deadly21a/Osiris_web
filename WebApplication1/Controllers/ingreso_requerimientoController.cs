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
    public class ingreso_requerimientoController : Controller
    {
        private OsirisEntities db = new OsirisEntities();

        // GET: ingreso_requerimiento
        public ActionResult Index()
        {
            return View(db.VistaIngresoRequerimiento.ToList());
        }

        // GET: ingreso_requerimiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingreso_requerimiento ingreso_requerimiento = db.ingreso_requerimiento.Find(id);
            if (ingreso_requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(ingreso_requerimiento);
        }

        // GET: ingreso_requerimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ingreso_requerimiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ingreso_requerimiento,ID_Estado,ID_Solicitante,ID_Tipo_requerimiento,ID_Prioridad,Requerimiento,ID_Proyecto,ID_Aplicacion,Opcion,ID_Hardware,Comentario,fecha_ingreso,F_Plazo")] ingreso_requerimiento ingreso_requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.ingreso_requerimiento.Add(ingreso_requerimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingreso_requerimiento);
        }

        // GET: ingreso_requerimiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingreso_requerimiento ingreso_requerimiento = db.ingreso_requerimiento.Find(id);
            if (ingreso_requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(ingreso_requerimiento);
        }

        // POST: ingreso_requerimiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ingreso_requerimiento,ID_Estado,ID_Solicitante,ID_Tipo_requerimiento,ID_Prioridad,Requerimiento,ID_Proyecto,ID_Aplicacion,Opcion,ID_Hardware,Comentario,fecha_ingreso,F_Plazo")] ingreso_requerimiento ingreso_requerimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingreso_requerimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingreso_requerimiento);
        }

        // GET: ingreso_requerimiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ingreso_requerimiento ingreso_requerimiento = db.ingreso_requerimiento.Find(id);
            if (ingreso_requerimiento == null)
            {
                return HttpNotFound();
            }
            return View(ingreso_requerimiento);
        }

        // POST: ingreso_requerimiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ingreso_requerimiento ingreso_requerimiento = db.ingreso_requerimiento.Find(id);
            db.ingreso_requerimiento.Remove(ingreso_requerimiento);
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
