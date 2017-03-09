using System;
using WilliamHill.TechChallenge.Implementation;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: WilliamHill.TechChallenge.exe \"path to settled bets csv\", \"path to unsettled bets csv\"");
                return;
            }

            var settledFile = args[0];
            var unsettledFile = args[1];

            if (!System.IO.File.Exists(settledFile))
            {
                Console.WriteLine($"Cannot locate settled file: {settledFile}");
                Console.WriteLine("Usage: WilliamHill.TechChallenge.exe \"path to settled bets csv\", \"path to unsettled bets csv\"");
                return;
            }
            if (!System.IO.File.Exists(unsettledFile))
            {
                Console.WriteLine($"Cannot locate unsettled file: {unsettledFile}");
                Console.WriteLine("Usage: WilliamHill.TechChallenge.exe \"path to settled bets csv\", \"path to unsettled bets csv\"");
                return;
            }


            ITechChallengeConfig config = new TechChallengeConfig(settledFile, unsettledFile);
            if (config == null) throw new ArgumentNullException(nameof(config));

            var settledBets = FileProcessor.LoadFile(config.SettledFile);
            var unsettledBets = FileProcessor.LoadFile(config.UnsettledFile);

            var riskStrategyRunner = new RiskStrategyRunner(config);
            var results = riskStrategyRunner.Evaluate(settledBets, unsettledBets);

            foreach (var result in results)
                Console.WriteLine(result);

            Console.WriteLine();
            Console.WriteLine("Hit the enter key to continue ...");
            Console.ReadLine();
        }
    }
}