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
    public class SolicitantesController : Controller
    {
        private OsirisEntities db = new OsirisEntities();

        // GET: Solicitantes
        public ActionResult Index()
        {
            return View(db.Solicitante.ToList());
        }

        // GET: Solicitantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitante solicitante = db.Solicitante.Find(id);
            if (solicitante == null)
            {
                return HttpNotFound();
            }
            return View(solicitante);
        }

        // GET: Solicitantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Solicitantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Solicitante,Nombres")] Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                db.Solicitante.Add(solicitante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(solicitante);
        }

        // GET: Solicitantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitante solicitante = db.Solicitante.Find(id);
            if (solicitante == null)
            {
                return HttpNotFound();
            }
            return View(solicitante);
        }

        // POST: Solicitantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Solicitante,Nombres")] Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solicitante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solicitante);
        }

        // GET: Solicitantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Solicitante solicitante = db.Solicitante.Find(id);
            if (solicitante == null)
            {
                return HttpNotFound();
            }
            return View(solicitante);
        }

        // POST: Solicitantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitante solicitante = db.Solicitante.Find(id);
            db.Solicitante.Remove(solicitante);
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
