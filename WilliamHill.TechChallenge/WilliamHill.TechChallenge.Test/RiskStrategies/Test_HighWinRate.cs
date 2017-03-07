using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.TechChallenge.Implementation;
using WilliamHill.TechChallenge.Implementation.RiskStrategies;

namespace WilliamHill.TechChallenge.Test
{
    [TestClass]
    public class Test_RiskMetrics
    {
        private ITechChallengeConfig mConfig;

        [TestInitialize]
        public void Test_Initialize()
        {
            mConfig = new TechChallengeConfig {HighWinRateThreshold = 0.6};
        }


        [TestMethod]
        public void Test_HighWinRateForOneCustomer_Success()
        {
            var riskMetrics = new HighWinRate(mConfig.HighWinRateThreshold);

            Bet[] bets =
            {
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 1},
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 2},
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 3},
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 0},
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 10},
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 0},
                new Bet {Customer = 2, Settled = true, Stake = 1, Win = 0},
                new Bet {Customer = 2, Settled = true, Stake = 1, Win = 0},
                new Bet {Customer = 2, Settled = true, Stake = 1, Win = 1},
                new Bet {Customer = 3, Settled = false, Stake = 1, Win = 1}
            };
            var results = riskMetrics.Evaluate(bets.Where(bet => bet.Settled), new Bet[] {});

            Assert.AreEqual(1, results.Count(), "Only customer 1 has a high win rate");
            Assert.IsTrue(results.First().Equals("Customer 1 has a win rate of 0.67 which exceeds the threshold of 0.60"));
        }
    }
}