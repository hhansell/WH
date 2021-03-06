﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.TechChallenge.Implementation;
using WilliamHill.TechChallenge.Implementation.RiskStrategies;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Test.RiskStrategies
{
    [TestClass]
    public class Test_HighWinRate
    {
        private ITechChallengeConfig mConfig;

        [TestInitialize]
        public void Test_Initialize()
        {
            mConfig = new TestConfig { HighWinRateThreshold = 0.6};
        }


        [TestMethod]
        public void Test_HighWinRateForOneCustomer_Success()
        {
            var riskMetrics = new HighWinRate(mConfig.HighWinRateThreshold);

            Bet[] bets =
            {
                new Bet {Customer = 1, Stake = 1, Win = 1},
                new Bet {Customer = 1, Stake = 1, Win = 2},
                new Bet {Customer = 1, Stake = 1, Win = 3},
                new Bet {Customer = 1, Stake = 1, Win = 0},
                new Bet {Customer = 1, Stake = 1, Win = 10},
                new Bet {Customer = 1, Stake = 1, Win = 0},
                new Bet {Customer = 2, Stake = 1, Win = 0},
                new Bet {Customer = 2, Stake = 1, Win = 0},
                new Bet {Customer = 2, Stake = 1, Win = 1},
                new Bet {Customer = 3, Stake = 1, Win = 1}
            };
            var results = riskMetrics.Evaluate(bets, new Bet[] {});

            Assert.AreEqual(1, results.Count(), "Only customer 1 has a high win rate");
            Assert.IsTrue(results.Single().StartsWith($"UNUSUAL: Customer {bets[0].Customer} has a win rate of "));
        }

        #region Nested type: TestConfig

        private class TestConfig : ITechChallengeConfig
        {
            #region Implementation of ITechChallengeConfig

            public string SettledFile { get; set; }
            public string UnsettledFile { get; set; }
            public double HighWinRateThreshold { get; set; }
            public double StakeMultiplierThreshold { get; set; }
            public double HighStakeMultiplierThreshold { get; set; }
            public double HighWinningTreshold { get; set; }

            #endregion
        }

        #endregion
    }
}