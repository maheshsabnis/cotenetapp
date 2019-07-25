using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotenetapp.CustomFilters
{
    public class CustomException : IExceptionFilter
    {
        // the interface provides information
        // of Model To View with its properties
        // and annotations 
        private readonly IModelMetadataProvider modelMetadata;

        /// <summary>
        /// The depednency will be resolved by AddMvc() method
        /// accessed in ConfigureService() method of Startup class
        /// </summary>
        /// <param name="modelMetadata"></param>
        public CustomException(IModelMetadataProvider modelMetadata)
        {
            this.modelMetadata = modelMetadata;
        }
        public void OnException(ExceptionContext context)
        {
            // 1. Handle Exception
            context.ExceptionHandled = true;
            // 2. Read Exception Message
            string message = context.Exception.Message;
            // 3. Return to Error Page

            var result = new ViewResult()
            {
                 ViewName = "CustomError"
            };
            result.ViewData = new ViewDataDictionary(modelMetadata, context.ModelState);

            // 4. set values for ViewData so that it can be passed to View
            result.ViewData["ControllerName"] = context.RouteData.Values["controller"].ToString();
            result.ViewData["ActionName"] = context.RouteData.Values["action"].ToString();
            result.ViewData["ExceptionMessage"] = message;

            // 5. set the View Result
            context.Result = result;

        }
    }
}
