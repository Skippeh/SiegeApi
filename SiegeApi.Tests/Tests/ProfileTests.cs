using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using SiegeApi.Data;
using SiegeApi.Exceptions;
using SiegeApi.Models;

namespace SiegeApi.Tests.Tests
{
    [Order(1), SingleThreaded, NonParallelizable]
    public class ProfileTests
    {
        private UserProfile profile;
        
        [Test, Order(0)]
        public async Task GetByName()
        {
            try
            {
                profile = await Singletons.ApiClient.FindProfileAsync("skippy.usb", Platform.Uplay);
                Singletons.UserProfile = profile;
            }
            catch (NotLoggedInException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task GetByUserId()
        {
            try
            {
                var profilesById = await Singletons.ApiClient.FindProfilesAsync(profile.UserId);
                Assert.IsTrue(profilesById.All(profile2 => profile2.UserId == profile.UserId), "Returned profiles does not have matching user ids.");
            }
            catch (NotLoggedInException ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}