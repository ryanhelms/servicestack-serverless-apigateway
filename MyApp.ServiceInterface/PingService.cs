using Microsoft.AspNetCore.Http.Internal;
using MyApp.ServiceModel;
using ServiceStack.Text;
using ServiceStack.Web;


namespace MyApp.ServiceInterface
{
    using ServiceStack;
    using System;

    /// <summary>
    /// Defines the <see cref="PingService" />
    /// </summary>
    public class PingService : Service
    {
        #region Properties

        #endregion

        #region Methods

        /// <summary>
        /// The Any
        /// </summary>
        /// <param name="request">The <see cref="PingRequest"/></param>
        /// <returns>The <see cref="object"/></returns>
        public object Any(PingRequest request)
        {
            return new PingResponse
            {
                Ping = "Any: Pong",
                UpTime = $"Service has been up for {HostContext.AppHost.StartedAt.Subtract(DateTime.Now)}"
            };
        }

        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="request">The <see cref="PingRequest"/></param>
        /// <returns>The <see cref="object"/></returns>
        public object Get(PingRequest request)
        {
            return new PingResponse
            {
                Ping = "Get: Pong",
                UpTime = $"Service has been up for {HostContext.AppHost.StartedAt.Subtract(DateTime.Now)}"
            };
        }

        /// <summary>
        /// The Post
        /// </summary>
        /// <param name="request">The <see cref="PingRequest"/></param>
        /// <returns>The <see cref="object"/></returns>
        public object Post(PingRequest request)
        {
            return new PingResponse
            {
                Ping = "Post: Pong",
                Payload = request.Payload,
                UpTime = $"Service has been up for {HostContext.AppHost.StartedAt.Subtract(DateTime.Now)}"
            };
        }

        /// <summary>
        /// The Put
        /// </summary>
        /// <param name="request">The <see cref="PingRequest"/></param>
        /// <returns>The <see cref="object"/></returns>
        public object Put(PingRequest request)
        {
            return new PingResponse
            {
                Ping = "Put: Pong",
                Payload = request.Payload,
                UpTime = $"Service has been up for {HostContext.AppHost.StartedAt.Subtract(DateTime.Now)}"
            };
        }

        #endregion
    }
}
