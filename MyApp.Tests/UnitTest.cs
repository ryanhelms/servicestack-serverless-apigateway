using MyApp.ServiceInterface;
using MyApp.ServiceModel;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;

namespace MyApp.Tests
{
    /// <summary>
    /// Defines the <see cref="UnitTest" /> 
    /// </summary>
    public class UnitTest
    {
        #region Private Fields

        /// <summary>
        /// Defines the appHost 
        /// </summary>
        private readonly ServiceStackHost appHost;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitTest" /> class. 
        /// </summary>
        public UnitTest()
        {
            appHost = new BasicAppHost().Init();
            appHost.Container.AddTransient<MyServices>();
        }

        #endregion Public Constructors



        #region Public Methods

        /// <summary>
        /// The Can_call_MyServices 
        /// </summary>
        [Test]
        public void Can_call_MyServices()
        {
            var service = appHost.Container.Resolve<MyServices>();

            var response = (HelloResponse)service.Any(new Hello { Name = "World" });

            Assert.That(response.Result, Is.EqualTo("Hello, World!"));
        }

        /// <summary>
        /// The OneTimeTearDown 
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        #endregion Public Methods
    }
}