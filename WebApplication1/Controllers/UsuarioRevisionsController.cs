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
    public class UsuarioRevisionsController : Controller
    {
        private OsirisEntities db = new OsirisEntities();

        // GET: UsuarioRevisions
        public ActionResult Index()
        {
            return View(db.UsuarioRevision.ToList());
        }

        // GET: UsuarioRevisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioRevision usuarioRevision = db.UsuarioRevision.Find(id);
            if (usuarioRevision == null)
            {
                return HttpNotFound();
            }
            return View(usuarioRevision);
        }

        // GET: UsuarioRevisions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioRevisions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Usuario,TipoUsuario")] UsuarioRevision usuarioRevision)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioRevision.Add(usuarioRevision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarioRevision);
        }

        // GET: UsuarioRevisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioRevision usuarioRevision = db.UsuarioRevision.Find(id);
            if (usuarioRevision == null)
            {
                return HttpNotFound();
            }
            return View(usuarioRevision);
        }

        // POST: UsuarioRevisions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Usuario,TipoUsuario")] UsuarioRevision usuarioRevision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioRevision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarioRevision);
        }

        // GET: UsuarioRevisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioRevision usuarioRevision = db.UsuarioRevision.Find(id);
            if (usuarioRevision == null)
            {
                return HttpNotFound();
            }
            return View(usuarioRevision);
        }

        // POST: UsuarioRevisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioRevision usuarioRevision = db.UsuarioRevision.Find(id);
            db.UsuarioRevision.Remove(usuarioRevision);
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
