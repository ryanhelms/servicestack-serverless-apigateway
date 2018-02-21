using Funq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyApp.ServiceInterface;
using ServiceStack;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyApp
{
    /// <summary>
    /// Defines the <see cref="AppHost" /> 
    /// </summary>
    public class AppHost : AppHostBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppHost" /> class. 
        /// </summary>
        public AppHost() : base("MyApp", typeof(MyServices).Assembly)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// The Configure 
        /// </summary>
        /// <param name="container">
        /// The <see cref="Container" /> 
        /// </param>
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                AdminAuthSecret = "1",
                DebugMode = true
            });

            Plugins.Add(new RequestLogsFeature());
            //Plugins.Add(new RequestInfoFeature());
            //Plugins.Add(new TemplatePagesFeature
            //{
            //    EnableDebugTemplate = true
            //});
        }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="Program" /> 
    /// </summary>
    public class Program
    {
        #region Methods

        /// <summary>
        /// The Main 
        /// </summary>
        /// <param name="args">
        /// The <see cref="string[]" /> 
        /// </param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls(Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://localhost:5000/")
                .Build();

            host.Run();
        }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="Startup" /> 
    /// </summary>
    public class Startup
    {
        #region Methods

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// The Configure 
        /// </summary>
        /// <param name="app">
        /// The <see cref="IApplicationBuilder" /> 
        /// </param>
        /// <param name="env">
        /// The <see cref="IHostingEnvironment" /> 
        /// </param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseServiceStack(new AppHost());

            app.Run(context =>
            {
                context.Response.Redirect("/demo/metadata");
                return Task.FromResult(0);
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// The ConfigureServices 
        /// </summary>
        /// <param name="services">
        /// The <see cref="IServiceCollection" /> 
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
        }

        #endregion
    }
}
