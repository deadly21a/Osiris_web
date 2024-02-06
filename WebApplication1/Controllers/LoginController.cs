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
                    
                    var loginViewModel = new LoginViewModel
                    {
                       
                      
                        CDsNombre = usuario.CDsNombre,
                        CDsApellido = usuario.CDsApellido
                        
                    };

                    
                    return RedirectToAction("Index", "Home", loginViewModel);
                }
                else
                {
                    
                    ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                    return View(model);
                }
            }

            
            return View(model);
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