using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TimeZebra.TimeManagement.Api.HealthCheck
{
    public class HealthCheckerResponseProvider
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public HealthCheckerResponseProvider(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public Task Writer(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";
            var dt = DateTime.Now;
            var settings = new
            {
                Message = "Hello, Welcome to TimeManagement Api",
                EnvironmentName = _hostingEnvironment.EnvironmentName,
                LocalDate = dt,
                UtcDate = dt.ToUniversalTime(),
                Status = result.Status.ToString()
            };

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(settings, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));
        }
    }
}