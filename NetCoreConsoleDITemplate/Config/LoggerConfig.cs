using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;

namespace NetCoreConsoleDITemplate
{
    internal class LoggerConfig
    {
        internal static ILoggerFactory GetLoggerFactory()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                    .AddConsole()
                    ;
            });

            loggerFactory.AddNLog();
            loggerFactory.ConfigureNLog("nlog.config");

            return loggerFactory;
        }

        internal static ILogger GetLogger<T>() where T : class
        {
            return GetLoggerFactory().CreateLogger<T>();
        }
    }
}