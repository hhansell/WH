using System;
using System.IO;
using System.Linq;

namespace WilliamHill.TechChallenge
{
    public class FileProcessor
    {
        private readonly string mSettledBetsFile;
        private readonly string mUnsettledBetsFile;

        public FileProcessor(ITechChallengeConfig config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));

            mSettledBetsFile = config.SettledFile;
            mUnsettledBetsFile = config.UnsettledFile;

            if (mSettledBetsFile == null) throw new ArgumentNullException(nameof(config.UnsettledFile));
            if (mUnsettledBetsFile == null) throw new ArgumentNullException(nameof(config.UnsettledFile));
        }

        public void Run()
        {
            var settledBets = File.ReadLines(mSettledBetsFile).SelectMany(line => line.Split(','));
            var unSettledBets = File.ReadLines(mUnsettledBetsFile).SelectMany(line => line.Split(','));
        }
    }
}