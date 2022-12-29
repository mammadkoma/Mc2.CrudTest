using FluentValidation;
using FluentValidation.AspNetCore;
using Mc2.CrudTest.Presentation.Server.Application.Common.Interfaces;
using Mc2.CrudTest.Presentation.Server.Application.Customers.Commands.CreateCustomer;
using Mc2.CrudTest.Presentation.Server.Infrastructure.Persistence;
using Mc2.CrudTest.Presentation.Server.Infrastructure.Services;
using Mc2.CrudTest.Presentation.Server.WebAppConfigs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddBadRequestHandlerService();
            services.AddRazorPages();
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataBaseConnection")));
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IStringService, StringService>();
            services.AddValidatorsFromAssemblyContaining<UpdateCustomerCommandValidator>();
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.AddExceptionHandlerService();
            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}