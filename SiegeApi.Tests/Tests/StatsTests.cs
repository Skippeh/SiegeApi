using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SiegeApi.Exceptions;
using SiegeApi.Models;

namespace SiegeApi.Tests.Tests
{
    [Order(2), SingleThreaded, NonParallelizable]
    public class StatsTests
    {
        [SetUp]
        public void Setup()
        {
            Monitor.Enter(Singletons.MonitorObject);
        }

        [TearDown]
        public void TearDown()
        {
            Monitor.Exit(Singletons.MonitorObject);
        }
        
        [Test]
        public async Task QueryStats()
        {
            try
            {
                UserStats statsFromUserProfile = await Singletons.ApiClient.GetStatsAsync(Singletons.UserProfile);
                Assert.NotNull(statsFromUserProfile, "Result of GetStatsAsync is null.");

                Dictionary<Guid, UserStats> statsFromUserId = await Singletons.ApiClient.GetStatsAsync(Singletons.UserProfile.Platform, Singletons.UserProfile.UserId);
                Assert.IsTrue(statsFromUserId.All(x => x.Key == Singletons.UserProfile.UserId), "Returned stats does not have matching user ids.");
            }
            catch (NotLoggedInException ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}