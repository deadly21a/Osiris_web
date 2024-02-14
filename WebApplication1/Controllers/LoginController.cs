using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
        public class LoginController : Controller
        {
        
            private PrometeoAdminEntities db = new PrometeoAdminEntities();

            // GET: Login
            public ActionResult Login()
            {
                return View();
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var usuario = db.tblAdUsuario.FirstOrDefault(u => u.CCiUsuario == model.CCiUsuario && u.CTxClave == model.CTxClave);

                if (usuario != null)
                {
                    
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {

                        ViewBag.Mensaje = "Usuario y/o contraseña incorrectos";
                        return View();
                    }
                }

                return View(model);
            }
        public ActionResult Logout()
        {
           
            return RedirectToAction("Login", "Login");
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