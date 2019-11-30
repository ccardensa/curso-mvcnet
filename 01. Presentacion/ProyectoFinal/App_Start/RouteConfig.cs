using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProyectoFinal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //El Router Default solo debe existir una vez

            routes.MapRoute(
                name: "Default",
                url: "inicio",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "",
                url: "quienes-somos",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            //El navegador ejecutará las url de acuerdo al orden del RouteConfig si este esta configurado (orden jerarquico)
            routes.MapRoute(
                name: "",
                url: "crear/factura",
                defaults: new { controller = "ProcesoFact", action = "Index", numeroFactura = UrlParameter.Optional, id = (string)null }
            );

            routes.MapRoute(
                name: "",
                url: "crear-factura",
                defaults: new { controller = "ProcesoFact", action = "Index", numeroFactura = UrlParameter.Optional, id = (string)null }
            );

            //routes.MapRoute(
            //    name: "",
            //    url: "editar-factura/{id}",
            //    defaults: new { controller = "ProcesoFact", action = "Index", id = UrlParameter.Optional}
            //);

            //Facturacion
            routes.MapRoute(
                name: "",
                url: "editar-factura/{id}",
                defaults: new { controller = "ProcesoFact", action = "Editar", id = UrlParameter.Optional }
            );

            //OrdenCompra

        }
    }
}
