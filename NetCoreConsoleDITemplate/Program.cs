using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreConsoleDITemplate
{
    public class Program
    {
        private readonly IMyService _myService;
        private readonly ILogger _logger;
        public Program(IMyService myService, ILogger logger)
        {
            _myService = myService;
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("Program has been started! ");
            _myService.DoTaskA();
            _myService.DoTaskB();
            _logger.LogInformation("Program has been finished! ");
        }
    }
}
