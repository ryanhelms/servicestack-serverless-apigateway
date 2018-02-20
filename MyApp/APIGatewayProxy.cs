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
        /// The FunctionHandlerAsync 
        /// </summary>
        /// <param name="request">
        /// The <see cref="APIGatewayProxyRequest" /> 
        /// </param>
        /// <param name="lambdaContext">
        /// The <see cref="ILambdaContext" /> 
        /// </param>
        /// <returns>
        /// The <see cref="Task{APIGatewayProxyResponse}" /> 
        /// </returns>
        public override Task<APIGatewayProxyResponse> FunctionHandlerAsync(APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            Log("||FunctionHandlerAsync||", "Request:", request.ToJson());
            Log("||FunctionHandlerAsync||", "Context:", lambdaContext.ToJson());

            try
            {
                Log("||FunctionHandlerAsync||", "Begin Executing base.FunctionHandlerAsync(request, lambdaContext)");

                var response = base.FunctionHandlerAsync(request, lambdaContext);

                Log("||FunctionHandlerAsync||", "Finished Executing base.FunctionHandlerAsync(request, lambdaContext)");
                Log("||FunctionHandlerAsync||", "");

                return response;
            }
            catch (AggregateException ex)
            {
                Log("||FunctionHandlerAsync-Exception||", "Exception:", ex?.Message);

                ex.InnerExceptions.Each((x, iex) => { Log("||FunctionHandlerAsync-Exception||", $"Inner Exception #{x}:", iex?.ToString()); });
            }
            catch (Exception ex)
            {
                Log("||FunctionHandlerAsync-Exception||", "Exception:", ex?.ToString());
            }

            return new APIGatewayProxyResponse
            {
                Body = new { Message = "An error has occured. All exceptions have been logged." }.ToJson()
            }
            .AsTaskResult();
        }

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

        /// <summary>
        /// The PostCreateContext
        /// </summary>
        /// <param name="context">The <see cref="HostingApplication.Context"/></param>
        /// <param name="request">The <see cref="APIGatewayProxyRequest"/></param>
        /// <param name="lambdaContext">The <see cref="ILambdaContext"/></param>
        protected override void PostCreateContext(HostingApplication.Context context, APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            Log("||PostCreateContext||", "Request:", request.ToJson());
            Log("||PostCreateContext||", "Context:", lambdaContext.ToJson());
            Log("||PostCreateContext||", "Begin Executing : base.PostCreateContext()");
            Log("||PostCreateContext||", "Request.Body:", request.Body);

            //request.Body = request.Body.Trim().ToJson();
            //Log("||PostCreateContext||", "Request.Body:", request.Body);

            base.PostCreateContext(context, request, lambdaContext);

            Log("||PostCreateContext||", "Finished Executing : base.PostCreateContext()");
        }

        #endregion
    }
}
