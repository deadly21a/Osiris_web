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
    public class AplicacionsController : Controller
    {
        private OsirisEntities db = new OsirisEntities();

        // GET: Aplicacions
        public ActionResult Index()
        {
            return View(db.Aplicacion.ToList());
        }

        // GET: Aplicacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplicacion aplicacion = db.Aplicacion.Find(id);
            if (aplicacion == null)
            {
                return HttpNotFound();
            }
            return View(aplicacion);
        }

        // GET: Aplicacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aplicacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Aplicacion,TipoAplicacion")] Aplicacion aplicacion)
        {
            if (ModelState.IsValid)
            {
                db.Aplicacion.Add(aplicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aplicacion);
        }

        // GET: Aplicacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplicacion aplicacion = db.Aplicacion.Find(id);
            if (aplicacion == null)
            {
                return HttpNotFound();
            }
            return View(aplicacion);
        }

        // POST: Aplicacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Aplicacion,TipoAplicacion")] Aplicacion aplicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aplicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aplicacion);
        }

        // GET: Aplicacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplicacion aplicacion = db.Aplicacion.Find(id);
            if (aplicacion == null)
            {
                return HttpNotFound();
            }
            return View(aplicacion);
        }

        // POST: Aplicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aplicacion aplicacion = db.Aplicacion.Find(id);
            db.Aplicacion.Remove(aplicacion);
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
