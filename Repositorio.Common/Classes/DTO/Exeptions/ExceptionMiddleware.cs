using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace Repositorio.Common.Classes.DTO.Exeptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly bool _isDevelopment;

        public ExceptionMiddleware(RequestDelegate next, bool isDevelopment)
        {
            _next = next;
            _isDevelopment = isDevelopment;
        }


        /// <summary>
        /// Método que intercepta toda las peticiones del aplicativo (Middleware)
        /// Si se produce algun error se controlan
        /// </summary>
        /// <param name="httpContext">HttpContext de la aplicación</param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // Se controla la excepción
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            Task response;

            JsonSerializerSettings serializationSettings = new()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            switch (exception)
            {
                case System.ComponentModel.DataAnnotations.ValidationException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response = context.Response.WriteAsync(JsonConvert.SerializeObject(ex, serializationSettings));
                    break;
                case ApplicationException ex:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = context.Response.WriteAsync(ex.Message);
                    SendErrorService(ex, context);
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    response = context.Response.WriteAsync(JsonConvert.SerializeObject(exception, serializationSettings));
                    SendErrorService(exception, context);
                    break;
            }

            return response;
        }

        /// <summary>
        /// Permite usar la implementación de IErrorService pero validando si el objeto _errorService fue instanciado, permitiendo que no sea obligatorio referenciar IErrorService en los controladores
        /// </summary>
        /// <param name="e">De tipo Exception, cualquier clase que herede de Exception puede ser enviada por parámetro cómo objeto</param>
        protected void SendErrorService(Exception e, HttpContext context)
        {
            if (!_isDevelopment)
            {
                ElmahIoApi.Log(e, context);
            }
        }
    }
}
