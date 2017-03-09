using System.Collections.Generic;
using System.Linq;
using WilliamHill.TechChallenge.Implementation.RiskStrategies;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation
{
    /// <summary>
    /// The Risk Strategy Runner runs all pre determined risk scenarios
    /// </summary>
    public class RiskStrategyRunner
    {
        private readonly List<IRiskStrategy> mRiskStrategies;

        public RiskStrategyRunner(ITechChallengeConfig config)
        {
            //TODO: This could be refactored to have the strategy list injected if multiple instances/configurations were required.
            mRiskStrategies = new List<IRiskStrategy>
            {
                new HighWinRate(config.HighWinRateThreshold),
                new UnsettledHighWinRate(config.HighWinRateThreshold),
                new UnsettledHighStakeBets(config.HighStakeMultiplierThreshold),
                new HighStakeBets(config.StakeMultiplierThreshold),
                new HighWinnings(config.HighWinningTreshold)
            };
        }

        public IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets)
        {
            return mRiskStrategies.SelectMany(strategy => strategy.Evaluate(settledBets, unsettledBets));
        }
    }
}