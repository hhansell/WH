using System.Collections.Generic;
using System.Linq;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation.RiskStrategies
{
    /// <summary>
    /// All upcoming (i.e. unsettled) bets from customers that win at an unusual rate should be highlighted as risky
    /// </summary>
    /// <seealso cref="WilliamHill.TechChallenge.Interfaces.IRiskStrategy" />
    public class UnsettledHighWinRate : IRiskStrategy
    {
        private readonly double mHighWinRateThreshold;

        public UnsettledHighWinRate(double highWinRateThreshold)
        {
            mHighWinRateThreshold = highWinRateThreshold;
        }

        #region IRiskStrategy Members

        public IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets)
        {
            var highWinRateCustomers = settledBets.GroupBy(bet => bet.Customer).Where(bet => bet.Count() > 1).Select(bets => new { Customer = bets.Key, WinRate = bets.Average(bet => bet.Win == 0 ? 0 : 1) }).Where(bets => bets.WinRate > mHighWinRateThreshold).Select(bet => bet.Customer);
            return
                unsettledBets.Join(highWinRateCustomers,
                    u => u.Customer,
                    s => s,
                    (u, s) => u).Select(bet => $"RISKY: Customer {bet.Customer} has been flagged with an unusual win rate for unsettled bet {bet}");
        }

        #endregion
    }
}