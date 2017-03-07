using System;
using WilliamHill.TechChallenge.Implementation;

namespace WilliamHill.TechChallenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ITechChallengeConfig config = new TechChallengeConfig(args[0], args[1]);
            if (config == null) throw new ArgumentNullException(nameof(config));

            var settledBets = FileProcessor.LoadFile(config.SettledFile);
            var unsettledBets = FileProcessor.LoadFile(config.UnsettledFile);

            var riskStrategyRunner = new RiskStrategyRunner(config);
            var results = riskStrategyRunner.Evaluate(settledBets, unsettledBets);

            foreach (var result in results)
                Console.WriteLine(result);
        }
    }
}