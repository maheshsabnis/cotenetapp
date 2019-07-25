using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace cotenetapp.CustomFilters
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {

        void LogRequest(string state, RouteData route)
        {
           
            string logMessage = $"Current State is {state}. " +
                $"The Controller is {route.Values["controller"]} " +
                $"and action is {route.Values["action"]}";

            Debug.WriteLine(logMessage);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            LogRequest("OnActionExecuting", context.RouteData);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            LogRequest("OnActionExecuted", context.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            LogRequest("OnResultExecuting", context.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            LogRequest("OnResultExecuted", context.RouteData);
        }
    }
}
