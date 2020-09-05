using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TimeZebra.Invoices.Api.Swagger
{
    public static class SwaggerServicesConfiguration
    {
        public static void Confirure(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.EnableAnnotations();

                    options.CustomSchemaIds(t => t.FullName.Replace("+", "."));

                    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Invoices API", Version = "v1" });

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);
                });
        }
    }
}