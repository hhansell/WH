using System.Collections.Generic;
using System.Linq;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation.RiskStrategies
{
    /// <summary>
    ///     Bets where the stake is more than 10 times higher than that customer’s average bet in their betting history should
    ///     be highlighted as unusual
    /// </summary>
    /// <seealso cref="WilliamHill.TechChallenge.Interfaces.IRiskStrategy" />
    public class UnsettledHighStakeBets : IRiskStrategy
    {
        private readonly double mStakeMultiplierThreshold;

        public UnsettledHighStakeBets(double stakeMultiplierThreshold)
        {
            mStakeMultiplierThreshold = stakeMultiplierThreshold;
        }

        #region IRiskStrategy Members

        public IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets)
        {
            var customerAverageBets = settledBets.GroupBy(bet => bet.Customer).Select(bets => new {Customer = bets.Key, AverageThreshold = bets.Average(bet => bet.Stake) * mStakeMultiplierThreshold});
            return
                unsettledBets.Join(customerAverageBets, u => u.Customer, s => s.Customer, (u, s) => new {UnsettledBet = u, s.AverageThreshold})
                    .Where(bet => bet.UnsettledBet.Stake > bet.AverageThreshold)
                    .Select(bet => $"UNUSUAL: Customer {bet.UnsettledBet.Customer} has been flagged with an unusually high stake for an unsettled bet {bet.UnsettledBet}");
        }

        #endregion
    }
}