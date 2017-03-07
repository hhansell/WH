using System.Collections.Generic;
using System.Linq;
using WilliamHill.TechChallenge.Implementation.RiskStrategies;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation
{
    public class RiskStrategyRunner 
    {
        private readonly List<IRiskStrategy> mRiskStrategies;

        public RiskStrategyRunner(ITechChallengeConfig config)
        {
            mRiskStrategies = new List<IRiskStrategy>
            {
                new HighWinRate(config.HighWinRateThreshold)
            };
        }

        public IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets)
        {
            return mRiskStrategies.SelectMany(strategy => strategy.Evaluate(settledBets, unsettledBets));
        }
    }
}