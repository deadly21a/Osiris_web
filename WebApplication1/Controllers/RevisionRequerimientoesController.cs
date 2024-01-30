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
    public class RevisionRequerimientoesController : Controller
    {
        private OsirisEntities db = new OsirisEntities();

        // GET: RevisionRequerimientoes
        public ActionResult Index()
        {
            return View(db.RevisionRequerimiento.ToList());
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

            return View(revisionRequerimiento);
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
    }
}
