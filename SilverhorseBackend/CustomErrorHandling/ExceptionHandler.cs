﻿using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SilverhorseDtos.ErrorDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SilverhorseBackend.CustomErrorHandling
{
    public class ExceptionHandler
    {

        private readonly RequestDelegate _next;
        private readonly ILoggerManager _logger;

        public ExceptionHandler(RequestDelegate next, ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error Occurred."
            }.ToString());
        }

    }
}
