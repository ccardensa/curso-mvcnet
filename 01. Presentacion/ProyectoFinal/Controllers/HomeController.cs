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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        //comment: https://stackify.com/log4net-guide-dotnet-logging/
        public ActionResult Log()
        {
            try
            {
                int suma = 0;
                var total = 1 / suma;               
            }
            catch (Exception ex)
            {
                log.Fatal("ERRORRRR FATAAAALLL CORRRAAAAANNN!");                
            }

            return View();
        }
    }
}