using AplicacionDigital.Services.ApplicationService;
using AplicacionDigital.Services.Contracts;
using AplicacionDigital.Services.DTOs;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AplicacionDigital.Services.ConfigurationDI
{
    public static class ConfigurationsInjeccionProfile
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection servises)
        {
            return servises.AddTransient<IBooksAppServices, BooksAppServices>()
                .AddTransient<IAuthorsAppServices, AuthorsAppServices>()
                .AddTransient<IPublisherAppServices, PublisherAppServices>()
                .AddAutoMapper(Assembly.GetExecutingAssembly());

        }

        public static IServiceCollection AddServiceValidationModel(this IServiceCollection servises)
        {
            servises.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidationsAuthors>())
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidationBooks>())
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ValidationsPublisher>());            
            return servises;
        }
    }
}
