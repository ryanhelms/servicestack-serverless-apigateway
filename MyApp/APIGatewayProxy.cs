﻿using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.AspNetCore.Hosting;
using ServiceStack;
using ServiceStack.Text;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using static Enumis.Utilities.Extensions.LoggingExtensions;

namespace MyApp
{
    /// <summary>
    /// Defines the <see cref="APIGatewayProxy" /> 
    /// </summary>
    public class APIGatewayProxy : Amazon.Lambda.AspNetCoreServer.APIGatewayProxyFunction
    {
        #region Public Methods

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
            Log("||FunctionHandlerAsync||", "Request:", request.Dump());
            Log("||FunctionHandlerAsync||", "Context:", lambdaContext.Dump());

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

        #endregion Public Methods



        #region Protected Methods

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

        protected override void PostCreateContext(HostingApplication.Context context, APIGatewayProxyRequest request, ILambdaContext lambdaContext)
        {
            Log("||PostCreateContext||", "Request:", request.Dump());
            Log("||PostCreateContext||", "Context:", lambdaContext.Dump());
            //Log("||PostCreateContext||", "HttpContext.User:", context.HttpContext.User.ToSafeJson());
            //Log("||PostCreateContext||", "HttpContext.Request:", context.HttpContext.Request.ToSafeJson());
            //Log("||PostCreateContext||", "HttpContext.Items:", context.HttpContext.Items.ToSafeJson());

            Log("||PostCreateContext||", "Begin Executing : base.PostCreateContext()");

            base.PostCreateContext(context, request, lambdaContext);

            Log("||PostCreateContext||", "Finished Executing : base.PostCreateContext()");
        }

        #endregion Protected Methods
    }
}