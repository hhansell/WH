using System.Collections.Generic;
using System.Linq;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation.RiskStrategies
{
    /// <summary>
    /// Bets where the amount to be won is $1000 or more.
    /// </summary>
    /// <seealso cref="WilliamHill.TechChallenge.Interfaces.IRiskStrategy" />
    public class HighWinnings : IRiskStrategy
    {
        private readonly double mHighWinningTreshold;

        public HighWinnings(double highWinningTreshold)
        {
            mHighWinningTreshold = highWinningTreshold;
        }

        #region IRiskStrategy Members

        public IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets)
        {
            return
                unsettledBets
                    .Where(bet => bet.Win >= mHighWinningTreshold)
                    .Select(bet => $"UNUSUAL: Customer {bet.Customer} has exceeded the high win threshold of {mHighWinningTreshold:0.00} {bet}");
        }

        #endregion
    }
}