using System;
using MyApp.ServiceModel;

namespace MyApp.ServiceInterface
{
    using ServiceStack;

    /// <summary>
    /// Defines the <see cref="PingService" /> 
    /// </summary>
    public class PingService : Service
    {
        #region Methods

        /// <summary>
        /// The Any 
        /// </summary>
        /// <param name="request">
        /// The <see cref="PingRequest" /> 
        /// </param>
        /// <returns>
        /// The <see cref="object" /> 
        /// </returns>
        public object Any(PingRequest request)
        {
            return new PingResponse
            {
                UpTime = $"Service has been up for {DateTime.Now.Subtract(HostContext.AppHost.StartedAt)}"
            };
        }

        /// <summary>
        /// The Get 
        /// </summary>
        /// <param name="request">
        /// The <see cref="PingRequest" /> 
        /// </param>
        /// <returns>
        /// The <see cref="object" /> 
        /// </returns>
        public object Get(PingRequest request)
        {
            return new PingResponse
            {
                Ping = "Get: Pong",
                UpTime = $"Service has been up for {DateTime.Now.Subtract(HostContext.AppHost.StartedAt)}"
            };
        }

        /// <summary>
        /// The Post 
        /// </summary>
        /// <param name="request">
        /// The <see cref="PingRequest" /> 
        /// </param>
        /// <returns>
        /// The <see cref="object" /> 
        /// </returns>
        public object Post(PingRequest request)
        {
            return new PingResponse
            {
                Ping = $"Post: Pong => Request: {request.ToJson()}",
                UpTime = $"Service has been up for {DateTime.Now.Subtract(HostContext.AppHost.StartedAt)}"
            };
        }

        /// <summary>
        /// The Put 
        /// </summary>
        /// <param name="request">
        /// The <see cref="PingRequest" /> 
        /// </param>
        /// <returns>
        /// The <see cref="object" /> 
        /// </returns>
        public object Put(PingRequest request)
        {
            return new PingResponse
            {
                Ping = $"Put: Pong => Request: {request.ToJson()}",
                UpTime = $"Service has been up for {DateTime.Now.Subtract(HostContext.AppHost.StartedAt)}"
            };
        }

        #endregion
    }
}
