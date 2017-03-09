using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.TechChallenge.Implementation;
using WilliamHill.TechChallenge.Implementation.RiskStrategies;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Test.RiskStrategies
{
    [TestClass]
    public class Test_UnsettledHighWinRate
    {
        private ITechChallengeConfig mConfig;

        [TestInitialize]
        public void Test_Initialize()
        {
            mConfig = new TestConfig { HighWinRateThreshold = 0.6};
        }


        [TestMethod]
        public void Test_UnusualUnsettledWinRateForOneCustomer_Success()
        {
            var riskMetrics = new UnsettledHighWinRate(mConfig.HighWinRateThreshold);

            Bet[] settledBets =
            {
                new Bet {Customer = 1, Stake = 1, Win = 1},
                new Bet {Customer = 1, Stake = 1, Win = 2},
                new Bet {Customer = 1, Stake = 1, Win = 3},
                new Bet {Customer = 1, Stake = 1, Win = 50},
                new Bet {Customer = 1, Stake = 1, Win = 0},
                new Bet {Customer = 2, Stake = 1, Win = 0},
                new Bet {Customer = 2, Stake = 1, Win = 0},
                new Bet {Customer = 2, Stake = 1, Win = 1},
                new Bet {Customer = 3, Stake = 1, Win = 1}
            };
            var unsettledBets = new Bet[] { new Bet { Customer = 1, Stake = 1, Win = 100 }, new Bet { Customer = 3, Stake = 1, Win = 1 }};
            var results = riskMetrics.Evaluate(settledBets,  unsettledBets );

            Assert.IsTrue(results.Single().Equals($"RISKY: Customer {unsettledBets[0].Customer} has been flagged with an unusual win rate for unsettled bet {unsettledBets[0]}"));
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