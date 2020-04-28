using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleDITemplate.Services
{
    public class MyService : IMyService
    {
        private readonly AppSettings _appConfig;
        private readonly ILogger _logger;
        public MyService(AppSettings myAppSettings, ILogger logger)
        {
            _appConfig = myAppSettings;
            _logger = logger;
        }

        public void DoTaskA()
        {
            // Do something .. 1 
            _logger.LogInformation("Task A has been started!");

            _logger.LogInformation(String.Format("KeyA is {0}", _appConfig.KeyA));
        }

        public void DoTaskB()
        {
            // Do something .. 2 
            _logger.LogInformation("Task B has been started!");

            _logger.LogInformation("Reading List A ");
            foreach (var item in _appConfig.ListA)
            {
                _logger.LogInformation(String.Format("Key is {0}, Value is {1}", item.Key, item.Value));
            }
        }
    }
}
