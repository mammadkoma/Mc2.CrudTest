using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace Mc2.CrudTest.Presentation.Server.WebAppConfigs
{
    public static class ExceptionConfig
    {
        public static void AddExceptionHandlerService(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = 500,
                            Message = CheckException(contextFeature.Error)
                        });
                    }
                });
            });
        }

        private static string CheckException(Exception ex)
        {
            if (ex.InnerException is not null)
                return ex.Message + " - InnerException : " + ex.InnerException.Message;

            return ex.Message;
        }
    }
}