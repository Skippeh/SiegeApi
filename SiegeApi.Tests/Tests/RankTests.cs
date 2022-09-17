using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SiegeApi.Data;
using SiegeApi.Exceptions;
using SiegeApi.Models;

namespace SiegeApi.Tests.Tests
{
    [Order(2), SingleThreaded, NonParallelizable]
    [TestFixture]
    public class RankTests
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
        public async Task QuerySingleRank()
        {
            UserProfile profile = Singletons.UserProfile;
            
            try
            {
                Dictionary<Guid, RankStats> rankStats = await Singletons.ApiClient.GetRanksAsync(profile.Platform, Region.Europe, Seasons.CurrentSeason, profile.UserId);
                Assert.IsTrue(rankStats.ContainsKey(profile.UserId), "Returned rank stats does not have stats for the specified user id.");

                Assert.That(rankStats[profile.UserId].SeasonId, Is.EqualTo(Seasons.CurrentSeason.Id), "Returned season does not match the requested season.");
                Assert.That(rankStats[profile.UserId].Region, Is.EqualTo(Region.Europe), "Returned region does not match the requested region.");
            }
            catch (NotLoggedInException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task QueryRanksBySeason()
        {
            UserProfile profile = Singletons.UserProfile;

            try
            {
                Dictionary<Guid, Dictionary<Region, RankStats>> allRankStats = await Singletons.ApiClient.GetRanksAsync(profile.Platform, Seasons.CurrentSeason, profile.UserId);
                Assert.IsTrue(allRankStats.ContainsKey(profile.UserId), "Returned rank stats does not have stats for the specified user id.");

                foreach (RankStats rankStats in allRankStats[profile.UserId].Values)
                {
                    Assert.IsTrue(rankStats.SeasonId == Seasons.CurrentSeason.Id, "Returned season does not match the requested season.");
                }
            }
            catch (NotLoggedInException ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        public async Task QueryRanksByRegion()
        {
            UserProfile profile = Singletons.UserProfile;

            try
            {
                Dictionary<Guid, Dictionary<Season, RankStats>> allRankStats = await Singletons.ApiClient.GetRanksAsync(profile.Platform, Region.Europe, profile.UserId);
                Assert.IsTrue(allRankStats.ContainsKey(profile.UserId), "Returned rank stats does not have stats for the specified user id.");
                
                foreach (RankStats rankStats in allRankStats[profile.UserId].Values)
                {
                    Assert.IsTrue(rankStats.Region == Region.Europe, "Returned region does not match the requested region.");
                }
            }
            catch (NotLoggedInException ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}