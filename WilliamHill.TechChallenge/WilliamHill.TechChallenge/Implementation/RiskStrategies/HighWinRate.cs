using System.Collections.Generic;
using System.Linq;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation.RiskStrategies
{
    /// <summary>
    /// A customer wins on more than 60% of their bets (i.e. in the settled bets data, they have a value in the “win” column for more than 60% of their bets)
    /// </summary>
    /// <seealso cref="WilliamHill.TechChallenge.Interfaces.IRiskStrategy" />
    public class HighWinRate : IRiskStrategy
    {
        private readonly double mHighWinRateThreshold;

        public HighWinRate(double highWinRateThreshold)
        {
            mHighWinRateThreshold = highWinRateThreshold;
        }

        #region IRiskStrategy Members

        public IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets)
        {
            return
                settledBets.GroupBy(bet => bet.Customer)
                    .Where(bet => bet.Count() > 1)
                    .Select(bets => new {Customer = bets.Key, WinRate = bets.Average(bet => bet.Win == 0 ? 0 : 1)})
                    .Where(bets => bets.WinRate > mHighWinRateThreshold)
                    .Select(bet => $"UNUSUAL: Customer {bet.Customer} has a win rate of {bet.WinRate:0.00} which exceeds the threshold of {mHighWinRateThreshold:0.00}");
        }

        #endregion
    }
}