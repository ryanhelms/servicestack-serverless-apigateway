using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Funq;
using ServiceStack;
using MyApp.ServiceInterface;
using MyApp.ServiceModel;
using ServiceStack.Web;

namespace MyApp
{
    public class Program
    {
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
    }

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseServiceStack(new AppHost());

            app.Run(context =>
            {
                context.Response.Redirect("/metadata");
                return Task.FromResult(0);
            });
        }
    }

    public class AppHost : AppHostBase
    {
        public AppHost() : base("MyApp", typeof(MyServices).Assembly) { }

        public override void Configure(Container container)
        {

            GlobalRequestFilters.Add((request, response, dto) =>
            {
                Console.WriteLine($"Incomming Request => {(request as IHttpRequest).ToSafeJson()}");
                Console.WriteLine($"Incomming Dto => {dto.ToSafeJson()}");

                try
                {
                    Console.WriteLine($"Original Request=> {request.OriginalRequest.ToSafeJson()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Original Form => unable to cast");
                }

            });
        }
        

    }
}