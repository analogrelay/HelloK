using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.Runtime;
using Microsoft.Framework.Runtime.Common.CommandLine;
using Microsoft.Framework.DependencyInjection;

namespace HelloK
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

    	public Configuration Configuration { get; set; }

    	public Startup(IHostingEnvironment env) 
    	{
    		Configuration = new Configuration();

            // Add global config
            if(File.Exists("config.json")) {
                Configuration.AddJsonFile("config.json");
            }
            
            // Add environment-specific config
            string envConfig = "config." + env.EnvironmentName.ToLowerInvariant() + ".json";
            if(File.Exists(envConfig)) {
                Configuration.AddJsonFile(envConfig);
            }

    		Configuration.AddEnvironmentVariables();
    	}

    	public void ConfigureServices(IServiceCollection services) 
    	{
    	}

    	public void Configure(IApplicationBuilder app) 
    	{
            app.UseErrorPage();
            app.Use(async (context, next) => {
                await context.Response.WriteLineAsync("ASP.NET 5");
                await context.Response.WriteLineAsync("Application Environment: " + _env.EnvironmentName);
                
                // await context.Response.WriteLineAsync("Configuration Sources:");
                // foreach(var source in Configuration) {
                //     await context.Response.WriteLineAsync(" " + source.GetType().FullName);
                // }

                // await next();
            });
    	}
    }
}