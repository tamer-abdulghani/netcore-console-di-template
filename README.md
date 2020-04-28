# NetCore 3 Console Dependency Injection Template 

This is a .net core console application which configured with dependency injection and NLog.

Before you run the project, make sure you change the properties of `appsettings` and `nlog.config` files: 

`CopyToOutputDirectory: Copy if newer`

* The application reads its configuration from `appsettings` file and bind it to AppSetting class.  
* The application integrate NLog library with ILogger: Check `Config/LoggerConfig`. 
* The application inject Sample Service called "MyService".   
* The NLog configuration are stored in `nlog.config` and the logs will be stored under `c:\temp\myprogram\` and 10 last logs will be always available in archive folder.  

## Sample output
```
info: NetCoreConsoleDITemplate.Program[0]
      Program has been started!
info: NetCoreConsoleDITemplate.Program[0]
      Task A has been started!
info: NetCoreConsoleDITemplate.Program[0]
      KeyA is value1
info: NetCoreConsoleDITemplate.Program[0]
      Task B has been started!
info: NetCoreConsoleDITemplate.Program[0]
      Reading List A
info: NetCoreConsoleDITemplate.Program[0]
      Key is A, Value is 123
info: NetCoreConsoleDITemplate.Program[0]
      Key is B, Value is BBB
info: NetCoreConsoleDITemplate.Program[0]
      Key is C, Value is zzz
info: NetCoreConsoleDITemplate.Program[0]
      Program has been finished!
```