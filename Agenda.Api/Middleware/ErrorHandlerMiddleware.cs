using Agenda.Api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Agenda.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }
        public async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            object error = new { Message = e.Message };

            switch (e)
            {
                case DomainException d:
                    _logger.LogError(e, "DOMAIN ERROR");
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case EntitynotfoundException n:
                    _logger.LogError(e, "ENTITY NOT FOUND");
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case Exception o:
                    _logger.LogError(e, "SERVER ERROR");
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var response = JsonSerializer.Serialize(error);

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(response);
        }
    }
}
