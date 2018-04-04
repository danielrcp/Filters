using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Filters
{
    public class CustomActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            WriteValues(filterContext.Controller, filterContext.ActionDescriptor, filterContext.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            WriteValues(filterContext.Controller, filterContext.ActionDescriptor, filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            WriteValues(filterContext.Controller, null, filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            WriteValues(filterContext.Controller, null, filterContext.RouteData);
        }

        private void WriteValues(ControllerBase controller, ActionDescriptor actionDescriptor, RouteData routeData,[CallerMemberName] string methodName = "")
        {
            string Message = $"Evento disparado {methodName}";
            Debug.WriteLine(Message,"CustomActionFilter");
            string ActionName = actionDescriptor != null ? actionDescriptor.ActionName : string.Empty;
            Message = $"Controller: {controller}, Action: {ActionName}";
            Debug.WriteLine(Message,"Controlador y Acción");

            foreach (var KeyValue in routeData.Values)
            {
                Message = $"Key: {KeyValue.Key}, Value: {KeyValue.Value}";
                Debug.WriteLine(Message,"Dato de la ruta");
            }
        }
    }
}