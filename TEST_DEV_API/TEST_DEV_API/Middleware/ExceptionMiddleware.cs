using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TEST_DEV_API.Errors;

namespace TEST_DEV_API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env )
        {
            this._next = next;
            this._logger = logger;
            this._env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //Se muestra el error en consola
                _logger.LogError(ex, ex.Message);
                //We need to specify we are returning a json because
                //we are not working within an API controller
                context.Response.ContentType = "application/json";
                //Se inicializa el status de error de nuestro servidor
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                //en caso de estar en el entorno de desarrollo se muestra como detalle
                //toda la pila de llamadas de nuestro programa, de lo contrario solo se 
                //envia al cliente el mensaje de Internal server error
                var response = _env.IsDevelopment()
                    ? new APIException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new APIException(context.Response.StatusCode, ex.Message, "Internal Server Error");
                //el objeto options maneja las opciones de formato de un json
                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                //convertimos en json la respuesta de nuestro server y la formateamos con
                //el objeto options
                var json = JsonSerializer.Serialize(response, options);

                //enviamos la respuesta al cliente
                await context.Response.WriteAsync(json);
            }
        }
    }
}
