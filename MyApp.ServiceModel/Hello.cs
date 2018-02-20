using ServiceStack;

namespace MyApp.ServiceModel
{
    /// <summary>
    /// Defines the <see cref="Hello" /> 
    /// </summary>
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Name 
        /// </summary>
        public string Name { get; set; }

        #endregion
    }

    /// <summary>
    /// Defines the <see cref="HelloResponse" /> 
    /// </summary>
    public class HelloResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Result 
        /// </summary>
        public string Result { get; set; }

        #endregion
    }
}
