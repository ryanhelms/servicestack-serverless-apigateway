using System.IO;
using ServiceStack;
using ServiceStack.Web;

namespace MyApp.ServiceModel
{
    /// <summary>
    /// Defines the <see cref="PingRequest" /> 
    /// </summary>
    [Route("/ping")]
    public class PingRequest : IReturn<PingResponse>, IRequiresRequestStream
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Payload 
        /// </summary>
        public string Payload { get; set; }

        #endregion Public Properties

        public Stream RequestStream { get; set; }
    }

    /// <summary>
    /// Defines the <see cref="PingResponse" /> 
    /// </summary>
    public class PingResponse
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Payload 
        /// </summary>
        public string Payload { get; set; }

        /// <summary>
        /// Gets or sets the Ping 
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

        public PingRequest Request { get; set; }
        public object RawRequest { get; set; }

        public object RequestStream { get; set; }

        #endregion Public Properties
    }
}