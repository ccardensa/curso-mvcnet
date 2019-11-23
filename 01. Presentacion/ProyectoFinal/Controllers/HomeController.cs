using cl.cursocsharp.dominio.contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
    public class HomeController : Controller
    {
        readonly IProcesoFacturacion ProcesoFacturacion;
        private IEjemplo Ejemplo;
        public HomeController(IProcesoFacturacion ProcesoFacturacion, IEjemplo Ejemplo
            )
        {
            this.ProcesoFacturacion = ProcesoFacturacion;
            this.Ejemplo = Ejemplo;
        }

        public ActionResult Index()
        {
            ProcesoFacturacion.CrearFactura();
            
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
    }
}