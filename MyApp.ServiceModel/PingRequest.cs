using ServiceStack;
using ServiceStack.Web;
using System.IO;

namespace MyApp.ServiceModel
{
    /// <summary>
    /// Defines the <see cref="PingRequest" /> 
    /// </summary>
    [Route("/ping")]
    public class PingRequest : IReturn<PingResponse>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Payload 
        /// </summary>
        public string Payload { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="PingResponse" /> 
    /// </summary>
    public class PingResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Payload 
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the Payload 
        /// </summary>
        public string Ping { get; set; }

        /// <summary>
        /// Gets or sets the ResponseStatus 
        /// </summary>
        public ResponseStatus ResponseStatus { get; set; }

        /// <summary>
        /// Gets or sets the UpTime
        /// </summary>
        public string UpTime { get; set; }

        #endregion
    }
}
