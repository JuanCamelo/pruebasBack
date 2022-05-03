using AplicacionDigital.Domain.Contracts;
using AplicacionDigital.Domain.DomainServices;
using AplicacionDigital.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AplicacionDigital.Domain.ConfgurationsDI
{
    public static class DataServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PRUEBASContext>(options => { options.UseSqlServer(configuration.GetConnectionString("DB_Connection")); });
            return services;
        }
    }
}
