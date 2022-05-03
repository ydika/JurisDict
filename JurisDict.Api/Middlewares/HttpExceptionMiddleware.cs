using AutoMapper;
using Common.DTOs;
using Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace JurisDict.Api.Middlewares
{
    public class HttpExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpExceptionMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var httpException = e as HttpException;
            if (httpException is null)
            {
                httpException = new HttpException(HttpStatusCode.InternalServerError, e);
            }

            var httpExceptionResponse = new HttpExceptionResponse()
            {
                StatusCode = (int)httpException.StatusCode,
                Message = httpException.Message,
                Url = context.Request.Path,
                StackTrace = httpException.StackTrace
            };

            context.Response.StatusCode = httpExceptionResponse.StatusCode;
            context.Response.ContentType = "application/json; charset=utf-8";

            var res = JsonSerializer.Serialize(httpExceptionResponse);
            return context.Response.WriteAsync(res);
        }
    }
}
