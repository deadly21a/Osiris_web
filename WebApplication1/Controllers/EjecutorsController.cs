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
    public class EjecutorsController : Controller
    {
        private OsirisEntities db = new OsirisEntities();

        // GET: Ejecutors
        public ActionResult Index()
        {
            return View(db.Ejecutor.ToList());
        }

        // GET: Ejecutors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejecutor ejecutor = db.Ejecutor.Find(id);
            if (ejecutor == null)
            {
                return HttpNotFound();
            }
            return View(ejecutor);
        }

        // GET: Ejecutors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ejecutors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Ejecutor,TipoEjecutor")] Ejecutor ejecutor)
        {
            if (ModelState.IsValid)
            {
                db.Ejecutor.Add(ejecutor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ejecutor);
        }

        // GET: Ejecutors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejecutor ejecutor = db.Ejecutor.Find(id);
            if (ejecutor == null)
            {
                return HttpNotFound();
            }
            return View(ejecutor);
        }

        // POST: Ejecutors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Ejecutor,TipoEjecutor")] Ejecutor ejecutor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ejecutor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ejecutor);
        }

        // GET: Ejecutors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ejecutor ejecutor = db.Ejecutor.Find(id);
            if (ejecutor == null)
            {
                return HttpNotFound();
            }
            return View(ejecutor);
        }

        // POST: Ejecutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ejecutor ejecutor = db.Ejecutor.Find(id);
            db.Ejecutor.Remove(ejecutor);
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
