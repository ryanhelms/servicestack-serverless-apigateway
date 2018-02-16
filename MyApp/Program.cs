using Funq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyApp.ServiceInterface;
using ServiceStack;
using ServiceStack.Web;
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
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AppHost" /> class. 
        /// </summary>
        public AppHost() : base("MyApp", typeof(MyServices).Assembly)
        {
        }

        #endregion Public Constructors



        #region Public Methods

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
                AdminAuthSecret = "1"
            });

            Plugins.Add(new RequestLogsFeature
            {
                Capacity = 100,
                LimitToServiceRequests = true,
                EnableErrorTracking = true,
                EnableResponseTracking = true
            });

            GlobalRequestFilters.Add((request, response, dto) =>
            {
                Console.WriteLine($"Incoming Request => {(request as IHttpRequest).ToSafeJson()}");
                Console.WriteLine($"Incoming Dto => {dto.ToSafeJson()}");

                try
                {
                    Console.WriteLine($"Original Request=> {request.OriginalRequest.ToSafeJson()}");
                }
                catch
                {
                    Console.WriteLine($"Original Form => unable to cast");
                }
            });
        }

        #endregion Public Methods
    }

    /// <summary>
    /// Defines the <see cref="Program" /> 
    /// </summary>
    public class Program
    {
        #region Public Methods

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

        #endregion Public Methods
    }

    /// <summary>
    /// Defines the <see cref="Startup" /> 
    /// </summary>
    public class Startup
    {
        #region Public Methods

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
                context.Response.Redirect("/metadata");
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

        #endregion Public Methods
    }
}