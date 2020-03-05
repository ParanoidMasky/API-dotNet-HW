using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Training.Exceptions
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = (HttpStatusCode)0;
            ExceptionStatusCodes.Map.TryGetValue(exception.GetType(), out statusCode);
            if (statusCode == 0)
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var jsonResponse = JsonConvert.SerializeObject(new { error = new { code = (int)statusCode, message = exception.Message } });
            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
