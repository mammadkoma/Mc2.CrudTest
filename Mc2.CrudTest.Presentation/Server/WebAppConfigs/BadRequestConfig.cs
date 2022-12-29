using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Mc2.CrudTest.Presentation.Server.WebAppConfigs
{
    public static class BadRequestConfig
    {
        public static IMvcBuilder AddBadRequestServices(this IMvcBuilder services)
        {
            services.ConfigureApiBehaviorOptions(options =>
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var modelState = actionContext.ModelState.Values;
                var allErrors = actionContext.ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(new
                {
                    StatusCode = 400,
                    Message = string.Join(" - ", allErrors.Select(e => e.ErrorMessage))
                });
            });

            return services;
        }
    }
}
