using Funq;
using MyApp.ServiceInterface;
using MyApp.ServiceModel;
using NUnit.Framework;
using ServiceStack;

namespace MyApp.Tests
{
    /// <summary>
    /// Defines the <see cref="IntegrationTest" /> 
    /// </summary>
    public class IntegrationTest
    {
        #region Private Fields

        /// <summary>
        /// Defines the BaseUri 
        /// </summary>
        private const string BaseUri = "http://localhost:2000/";

        /// <summary>
        /// Defines the appHost 
        /// </summary>
        private readonly ServiceStackHost appHost;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegrationTest" /> class. 
        /// </summary>
        public IntegrationTest()
        {
            appHost = new AppHost()
            .Init()
            .Start(BaseUri);
        }

        #endregion Public Constructors



        #region Public Methods

        /// <summary>
        /// The Can_call_Hello_Service 
        /// </summary>
        [Test]
        public void Can_call_Hello_Service()
        {
            var client = CreateClient();

            var response = client.Get(new Hello { Name = "World" });

            Assert.That(response.Result, Is.EqualTo("Hello, World!"));
        }

        /// <summary>
        /// The Can_call_Ping_Service_Via_Get 
        /// </summary>
        [Test]
        public void Can_call_Ping_Service_Via_Get()
        {
            var client = CreateClient();

            var response = client.Get(new PingRequest { Payload = "Some data" });

            Assert.That(response.Payload, Is.EqualTo(null));
        }

        /// <summary>
        /// The Can_call_Ping_Service_Via_Post 
        /// </summary>
        [Test]
        public void Can_call_Ping_Service_Via_Post()
        {
            var client = CreateClient();

            var response = client.Post(new PingRequest {Payload = "Some data"});
            
            Assert.That(response.Payload, Is.EqualTo("Some data"));
        }

        /// <summary>
        /// The CreateClient 
        /// </summary>
        /// <returns>
        /// The <see cref="IServiceClient" /> 
        /// </returns>
        public IServiceClient CreateClient() => new JsonServiceClient(BaseUri);

        /// <summary>
        /// The OneTimeTearDown 
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        #endregion Public Methods



        #region Private Classes

        /// <summary>
        /// Defines the <see cref="AppHost" /> 
        /// </summary>
        private class AppHost : AppSelfHostBase
        {
            #region Public Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="AppHost" /> class. 
            /// </summary>
            public AppHost() : base(nameof(IntegrationTest), typeof(MyServices).Assembly)
            {
            }

            #endregion Public Constructors



            #region Public Methods

            /// <summary>
            /// The Configure 
            /// </summary>
            /// <param name="container">
            /// The <see cref="Container" /> 
            /// </param>
            public override void Configure(Container container)
            {
            }

            #endregion Public Methods
        }

        #endregion Private Classes
    }
}