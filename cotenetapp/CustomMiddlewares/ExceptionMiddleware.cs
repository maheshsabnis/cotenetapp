using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cotenetapp.CustomMiddlewares
{
    /// <summary>
    ///  Data class that will define schema for error
    /// </summary>
    public class ErrorDetails
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
    /// <summary>
    /// Custom middleware class
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate request;

        public ExceptionMiddleware(RequestDelegate request)
        {
            this.request = request;
        }

        /// <summary>
        /// Logic Method. This method will continue for no errors
        /// else hault execution when error occure
        /// </summary>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext ctx)
        {
            try
            {
                // continue execution with next middleware 
                // if no error
                await request(ctx);
            }
            catch (Exception ex)
            {
                // else handle exception and return response
                HandleError(ctx, ex);
            }
        }
        /// <summary>
        /// The actual Logic for error
        /// </summary>
        /// <param name="ctx"></param>
        /// <param name="ex"></param>
        private async void HandleError(HttpContext ctx, Exception ex)
        {
            // 1. define error code
            ctx.Response.StatusCode = 500;
            // 2. Read the Error Message
            string message = ex.Message;
            // 3. Manage the response
            var errorDetails = new ErrorDetails()
            {
                 ErrorCode = ctx.Response.StatusCode,
                 ErrorMessage = message
            };
            // 4. Convert the error object in JSON
            string errorMessage = JsonConvert.SerializeObject(errorDetails);
            // 5. write the response
            await ctx.Response.WriteAsync(errorMessage);
        }
    }

    // an extension class to register the custo midleware
    public static class CustomMiddlewareExtensions
    {
        public static void UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
