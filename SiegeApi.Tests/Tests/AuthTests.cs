using System.Threading.Tasks;
using NUnit.Framework;
using SiegeApi.Exceptions;
using SiegeApi.Tests.Configuration;

namespace SiegeApi.Tests.Tests
{
    [Order(0), SingleThreaded, NonParallelizable]
    [TestFixture]
    public class AuthTests
    {
        private SiegeApiClient apiClient;
        private string loginErrorMessage;
        private Config config;
        
        [SetUp]
        public async Task Setup()
        {
            config = ConfigUtility.GetConfig(TestContext.CurrentContext.TestDirectory);
            
            apiClient = new SiegeApiClient();
            Singletons.ApiClient = apiClient;
            
            try
            {
                await apiClient.LoginAsync(config.UplayEmail, config.UplayPassword);
            }
            catch (LoginFailedException ex)
            {
                // Store error message and ignore exception. Login is verified in TestSetup.
                loginErrorMessage = ex.Message;
            }
        }

        [Test]
        public void TestLoggedIn()
        {
            Assert.IsTrue(apiClient.LoggedIn, loginErrorMessage);
        }
    }
}