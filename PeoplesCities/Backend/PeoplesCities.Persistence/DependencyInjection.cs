using Microsoft.EntityFrameworkCore;
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
            var connectionString = configuration["DbConnection"];
            string wireMockUrl = configuration.GetSection("WireMockSettings")["WireMockUrl"];
            bool isSQLiteProDbProvifer = Convert.ToBoolean(configuration["IsSQLiteProDbProvifer"]);

            services.AddDbContext<PeoplesCitiesDbContext>(options =>
            {
                if (isSQLiteProDbProvifer)  
                    options.UseSqlite(connectionString);
                else
                    options.UseNpgsql(connectionString);
            });
            services.AddScoped<IPeoplesCitiesDbContext>(provider => provider.GetService<PeoplesCitiesDbContext>());

            return services;
        }
    }
}
