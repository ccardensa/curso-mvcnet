using cl.cursocsharp.dominio.contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal.Controllers
{
   
    public class ProcesoFactController : Controller
    {
        readonly IProcesoFacturacion ProcesoFacturacion;
        
        public ProcesoFactController(IProcesoFacturacion ProcesoFacturacion)
        {
            this.ProcesoFacturacion = ProcesoFacturacion;
           
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ObtenerFactura(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerarFactura()
        {
            ProcesoFacturacion.CrearFactura();
            return View();
        }

        [HttpDelete]
        public ActionResult EliminarFactura()
        {
            return View();
        }

    }
}