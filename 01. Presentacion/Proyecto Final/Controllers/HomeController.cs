using PrimeraClase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeraClase.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            int numero = 200;
            int cero = 0;
            int total = numero / cero;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Ejemplo()
        {
            return View("Ejemplo2");
        }

        [HttpGet]       
        public ActionResult Usuario()
        {
            var usu = new Models.Usuario();
            return View(usu);
        }

        /// <summary>
        /// Captura de información del usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns>respuesta según se componga el modelo</returns>
        [HttpPost]
        public ActionResult Usuario(Usuario model)
        {
            if (model != null)
            {
                if (ModelState.IsValid)
                {                   
                    //TODO: guardar datos usuario
                }
                else {
                    //TODO: retornamos los errores a la vista
                }

                
            }

            return View();
        }

    }
}