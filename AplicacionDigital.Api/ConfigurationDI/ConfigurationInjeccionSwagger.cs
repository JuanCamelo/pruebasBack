using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace AplicacionDigital.Api.ConfigurationDI
{
    public static class ConfigurationInjeccionSwagger
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {

            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AplicacionDigital.Api", Version = "v1" });
            });
        }

        public static IApplicationBuilder AddSwaggerCollection(this IApplicationBuilder app)
        {
            return app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AplicacionDigital.Api v1"));
        }
    }
}
