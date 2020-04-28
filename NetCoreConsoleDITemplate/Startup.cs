using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NetCoreConsoleDITemplate.Services;
using System;
using System.IO;

namespace NetCoreConsoleDITemplate
{
    class Startup
    {
        static void Main(string[] args)
        {
            var configuration = Configuration();
            var services = ConfigureServices(configuration);

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger>();

            try
            {
                serviceProvider.GetService<Program>().Run();
            }
            catch (Exception e)
            {
                logger.LogError(e, "Exception was raised somewhere in Program");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        private static IConfiguration Configuration()
        {
            var appsettings = string.Format("appsettings.{0}.json", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(appsettings, optional: true, reloadOnChange: true);
            return builder.Build();
        }

        private static IServiceCollection ConfigureServices(IConfiguration configuration)
        {
            IServiceCollection services = new ServiceCollection();

            // Bind appsettings into C# object and inject it as service (MyAppSettings) 
            var config = new AppSettings();
            configuration.Bind("AppSettings", config);
            services.AddSingleton(config);

            // Configure logging
            services.AddSingleton(LoggerConfig.GetLogger<Program>());

            // Add services here
            services.AddTransient<IMyService, MyService>();

            // Add main program
            services.AddTransient<Program>();

            return services;
        }
    }
}
