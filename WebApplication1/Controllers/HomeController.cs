using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index(LoginViewModel loginViewModel)
        //{
        //    return View(loginViewModel);
        //}


        private readonly OsirisEntities _context;


        public HomeController()
        {
            _context = new OsirisEntities(); 
        }

        // GET: Home
        public ActionResult Index()
        {
         
            int requerimientosCount = _context.ingreso_requerimiento.Count(r => r.ID_Estado == 1);

            ViewBag.RequerimientosCount = requerimientosCount;


            int requerimientosCount1 = _context.ingreso_requerimiento.Count(r => r.ID_Estado == 2);

            ViewBag.RequerimientosCount1 = requerimientosCount1;



            int requerimientosCount2 = _context.ingreso_requerimiento.Count(r => r.ID_Estado == 3);

            ViewBag.RequerimientosCount2 = requerimientosCount2;

            int requerimientosCount3 = _context.ingreso_requerimiento.Count(r => r.ID_Estado == 5);

            ViewBag.RequerimientosCount3 = requerimientosCount3;
            return View();
        }

      

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
