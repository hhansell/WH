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
            mSettledBetsFile = config.SettledFile;
            mUnsettledBetsFile = config.UnsettledFile;

            if (mSettledBetsFile == null) throw new ArgumentNullException(nameof(config.UnsettledFile));
            if (mUnsettledBetsFile == null) throw new ArgumentNullException(nameof(config.UnsettledFile));
        }

        public void Run()
        {
            // first line contains the headers
            var settledBets = File.ReadLines(mSettledBetsFile).SelectMany(line => line.Split(',')).Skip(1);
            var unSettledBets = File.ReadLines(mUnsettledBetsFile).SelectMany(line => line.Split(',')).Skip(1);
        }
    }
}