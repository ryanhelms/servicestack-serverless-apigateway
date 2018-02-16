using MyApp.ServiceModel;
using ServiceStack;

namespace MyApp.ServiceInterface
{
    /// <summary>
    /// Defines the <see cref="MyServices" /> 
    /// </summary>
    public class MyServices : Service
    {
        #region Public Methods

        /// <summary>
        /// The Any 
        /// </summary>
        /// <param name="request">
        /// The <see cref="Hello" /> 
        /// </param>
        /// <returns>
        /// The <see cref="object" /> 
        /// </returns>
        public object Any(Hello request)
        {
            return new HelloResponse { Result = $"Hello, {request.Name}!" };
        }

        #endregion Public Methods
    }
}