using PeoplesCities.Persistence;
using Serilog;

namespace PeoplesCities.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                                      .WriteTo.File("LogFiles/PeoplesCities-.txt", rollingInterval: RollingInterval.Day)
                                      .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var context = serviceProvider.GetRequiredService<PeoplesCitiesDbContext>();
                    //WeatherStub.ConfigureStub();
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "An error occurred while app initialization");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
            //    .ConfigureAppConfiguration((hostingContext, config) =>
            //     {
            //config.AddJsonFile("appsettings.json", optional: true);
            //      });
    }
}