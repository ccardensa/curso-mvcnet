using cl.cursocsharp.dominio.contratos;
using ProyectoFinal.Models;
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
            var model = new FacturaDto();
            model.CabeceraDto = new CabeceraDto();
            model.DetalleDto = new DetalleDto();
            return View("EjemploScaffolding", model.CabeceraDto);
            //return View();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {           
            return RedirectToAction("About", "Home");
        }

        [HttpPost]
        public ActionResult GenerarFactura(FacturaDto model)
        {
            if (ModelState.IsValid)
            {

            }
            
            //ProcesoFacturacion.CrearFactura();
            return View("Index", model);
        }

        [HttpDelete]
        public ActionResult EliminarFactura()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Footer()
        {
            return PartialView("Footer");
        }

    }
}