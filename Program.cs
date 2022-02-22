using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Robot.Tools;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Robot
{
  
    public class Program
    {
        private static IConfigurationRoot config = null;
        private static LoggerConfiguration loggerConfiguration = null;
        public static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
          
            config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            Config.AppSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(Config.AppSettings);
        
            loggerConfiguration = new LoggerConfiguration()
                .WriteTo.File(
                     outputTemplate:"[{Timestamp:yyyy-MM-dd HH:mm:ss:fff} {Level:u3}] {Message:1}{NewLine}{Exception}",
                     path: Directory.GetCurrentDirectory() + @"\Logs\Log_.txt",
                     fileSizeLimitBytes:5242880,
                     flushToDiskInterval:TimeSpan.FromSeconds(1),
                     rollOnFileSizeLimit:true,
                     rollingInterval:RollingInterval.Hour,
                     retainedFileCountLimit:1000               
                );

            Log.Logger = loggerConfiguration.CreateLogger();
            Log.Information("Starting the API");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
