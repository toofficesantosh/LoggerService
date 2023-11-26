using LoggerLibrary.Implementation;
using LoggerLibrary;
using LoggerClient.Services;
using LoggerLibrary.Model;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LoggerClient.Model;

using IHost host = Host.CreateDefaultBuilder(args).Build();
IConfiguration configuration = host.Services.GetRequiredService<IConfiguration>();
ConfigExtention.Initialize(configuration);


//To call the LogService 
LoggerService.LogMessage(LogLevel.FATAL, "LoggerClient", "Fatal Error in the application");
LoggerService.LogMessage(LogLevel.ERROR, "LoggerClient", "An error occurred");
LoggerService.LogMessage(LogLevel.INFO, "LoggerClient", "This is an informational message");
LoggerService.LogMessage(LogLevel.DEBUG, "LoggerClient", "Debugging information");
Console.ReadLine();

