using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeoplesCities.Application.Interfaces;

namespace PeoplesCities.Persistence
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Метод расширения для добавления контекста базы данных и регистрации его веб приложений.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPeoplesCitiesDbContext>(provider => provider.GetService<PeoplesCitiesDbContext>());

            return services;
        }
    }
}
