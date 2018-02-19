using MyApp.ServiceModel;

namespace MyApp.ServiceInterface
{
    using ServiceStack;
    using System;

    /// <summary>
    /// Defines the <see cref="PingService" /> 
    /// </summary>
    public class PingService : Service
    {
        #region Public Methods

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
                Ping = "Any: Pong",
                Request = request
                //,UpTime = $"Service has been up for {DateTime.Now.Subtract(HostContext.AppHost.StartedAt)}"
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
                Request = request
                //,UpTime = $"Service has been up for {DateTime.Now.Subtract(HostContext.AppHost.StartedAt)}"
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
                Request = request,
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
                Ping = "Put: Pong",
                Payload = request.Payload,
                Request = request,
                //UpTime = $"Service has been up for {DateTime.Now.Subtract(HostContext.AppHost.StartedAt)}"
            };
        }

        #endregion Public Methods
    }
}