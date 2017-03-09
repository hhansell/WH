using System.Collections.Generic;
using System.Linq;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation.RiskStrategies
{
    /// <summary>
    /// Bets where the stake is more than 30 times higher than that customer’s average bet in their betting history should be highlighted as highly unusual
    /// </summary>
    /// <seealso cref="WilliamHill.TechChallenge.Interfaces.IRiskStrategy" />
    public class HighStakeBets : IRiskStrategy
    {
        private readonly double mStakeMultiplierThreshold;

        public HighStakeBets(double stakeMultiplierThreshold)
        {
            mStakeMultiplierThreshold = stakeMultiplierThreshold;
        }

        #region IRiskStrategy Members

        public IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets)
        {
            var customerAverageBets = settledBets.GroupBy(bet => bet.Customer).Select(bets => new { Customer = bets.Key, AverageThreshold = bets.Average(bet => bet.Stake) * mStakeMultiplierThreshold });
            return
            settledBets.Join(customerAverageBets, u => u.Customer, s => s.Customer, (u, s) => new {Bet = u, s.AverageThreshold})
                .Where(item => item.Bet.Stake > item.AverageThreshold)
                .Select(item => $"HIGHLY UNUSUAL: Customer {item.Bet.Customer} has been flagged with a high stake for a settled bet {item.Bet}. Their average stake is {item.AverageThreshold:00} and the high stake threshold has a multiplier of {mStakeMultiplierThreshold}")
                .Concat(
                    unsettledBets.Join(customerAverageBets, u => u.Customer, s => s.Customer, (u, s) => new {Bet = u, s.AverageThreshold})
                        .Where(item => item.Bet.Stake > item.AverageThreshold)
                        .Select(item => $"HIGHLY UNUSUAL: Customer {item.Bet.Customer} has been flagged with a high stake for a unsettled bet {item.Bet}. Their average stake is {item.AverageThreshold:00} and the high stake threshold has a multiplier of {mStakeMultiplierThreshold}")
                        );
        }

        #endregion
    }
}