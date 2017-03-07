using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation
{
    public class RiskMetrics : IRiskMetrics
    {
        private double mHighWinRateThreshold;

        public RiskMetrics(ITechChallengeConfig config)
        {
            mHighWinRateThreshold = config.HighWinRateThreshold;
        }

        public int[] GetHighWinRates(IEnumerable<Bet> settledBets)
        {
            var b= settledBets.GroupBy(bet => bet.Customer).Select(bets => new
            {
                Customer = bets.Key,
                WinRate = bets.Average(bet => bet.Win == 0 ? 0 : 1)
            });
            return b.Where(bets => bets.WinRate >= mHighWinRateThreshold).Select(bet => bet.Customer).ToArray();
        }
    }
}
