using ServiceStack;

namespace MyApp.ServiceModel
{
    /// <summary>
    /// Defines the <see cref="PingRequest" /> 
    /// </summary>
    [Route("/ping")]
    public class PingRequest : IReturn<PingResponse>
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the Payload 
        /// </summary>
        public string Payload { get; set; }

        #endregion Public Properties
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

        #endregion Public Properties
    }
}