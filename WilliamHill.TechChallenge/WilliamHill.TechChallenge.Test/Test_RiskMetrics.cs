using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.TechChallenge.Implementation;

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
            var riskMetrics = new RiskMetrics(mConfig);

            Bet[] bets =
            {
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 1},
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 2},
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 0},
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 10},
                new Bet {Customer = 1, Settled = true, Stake = 1, Win = 0},
                new Bet {Customer = 2, Settled = true, Stake = 1, Win = 0},
                new Bet {Customer = 2, Settled = true, Stake = 1, Win = 0},
                new Bet {Customer = 2, Settled = true, Stake = 1, Win = 1},
                new Bet {Customer = 3, Settled = false, Stake = 1, Win = 1}
            };
            var customers = riskMetrics.GetHighWinRates(bets.Where(bet => bet.Settled));

            Assert.AreEqual(1, customers.Length, "Only customer 1 has a high win rate");
            Assert.AreEqual(1, customers[0], "Customer of value 1 should be returned as they have a high win rate");
        }
    }
}