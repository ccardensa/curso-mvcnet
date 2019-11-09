using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeraClase.Filtros
{    
    //comment: para que nuestro gestor de errores sea un filtro
    //debemos agregar la linea attributeUsage
    [AttributeUsage(AttributeTargets.All)]
    public sealed class HandleError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
                filterContext = new ExceptionContext();


            if (!filterContext.ExceptionHandled && filterContext.HttpContext.IsCustomErrorEnabled)
            {
                FilterContext(filterContext);
            }

            base.OnException(filterContext);

        }

        /// <summary>
        /// Esta función envia el detalle de los errores a la vista de _error.chtml
        /// </summary>
        /// <param name="filterContext"></param>
        private static void FilterContext(ExceptionContext filterContext)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            bool isHabilitado = Convert.ToBoolean(ConfigurationManager.AppSettings["LogHabilitado"], CultureInfo.CurrentCulture);

#if DEBUG
            if (isHabilitado)
            {

            }
#endif

        }


    }
}