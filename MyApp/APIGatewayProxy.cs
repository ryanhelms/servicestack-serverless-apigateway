using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using ServiceStack;
using System;
using System.Threading.Tasks;
using static Enumis.Utilities.Extensions.LoggingExtensions;

namespace MyApp
{
    /// <summary>
    /// Defines the <see cref="APIGatewayProxy" /> 
    /// </summary>
    public class APIGatewayProxy : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        #region Methods
        
        /// <summary>
        /// The Init 
        /// </summary>
        /// <param name="builder">
        /// The <see cref="IWebHostBuilder" /> 
        /// </param>
        protected override void Init(IWebHostBuilder builder)
        {
            builder.UseStartup<Startup>().UseApiGateway();
        }
        
        #endregion
    }
}
