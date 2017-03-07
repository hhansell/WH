using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation.RiskStrategies
{
    public class HighWinRate : IRiskStrategy
    {

        private readonly double mHighWinRateThreshold;

        public HighWinRate(double highWinRateThreshold)
        {
            this.mHighWinRateThreshold = highWinRateThreshold;
        }

        public IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets)
        {
            var b = settledBets.GroupBy(bet => bet.Customer).Select(bets => new
            {
                Customer = bets.Key,
                WinRate = bets.Average(bet => bet.Win == 0 ? 0 : 1)
            });
            return
                b.Where(bets => bets.WinRate > mHighWinRateThreshold)
                    .Select(bet =>
                            $"Customer {bet.Customer} has a win rate of {bet.WinRate:0.00} which exceeds the threshold of {mHighWinRateThreshold:0.00}");
        }
    }
}
