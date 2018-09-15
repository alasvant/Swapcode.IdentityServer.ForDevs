using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Swapcode.IdentityServer.ForDevs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

            try
            {
                logger.Debug("Executing main");
                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Ending application because of unhandled exception during execution.");
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging((hostBuilder, loggingBuilder) => {
                    loggingBuilder.AddConfiguration(hostBuilder.Configuration.GetSection("Logging"));

                    if (hostBuilder.HostingEnvironment.IsDevelopment())
                    {
                        loggingBuilder.AddConsole();
                        loggingBuilder.AddDebug();
                    }

                    // this is overriden by appsettings.json if defined there with the LogLevel -> Default
                    loggingBuilder.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();
    }
}
