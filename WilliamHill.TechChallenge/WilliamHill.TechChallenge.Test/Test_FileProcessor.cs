using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.TechChallenge.Implementation;

namespace WilliamHill.TechChallenge.Test
{
    [TestClass]
    public class Test_FileProcessor
    {
        private ITechChallengeConfig mConfig;

        [TestInitialize]
        public void Test_Initialize()
        {
            var settledFile = System.IO.Path.Combine(Environment.CurrentDirectory, "TestData", "Settled.csv");
            var unsettledFile = System.IO.Path.Combine(Environment.CurrentDirectory, "TestData", "Unsettled.csv");
            mConfig = new TestConfig() { SettledFile= settledFile, UnsettledFile = unsettledFile};
        }

        [TestMethod]
        public void Test_FileProcessor_Load_Success()
        {
            var settledBets = FileProcessor.LoadFile(mConfig.SettledFile);
            var unsettledBets = FileProcessor.LoadFile(mConfig.UnsettledFile);
        }

        private class TestConfig : ITechChallengeConfig
        {
            public string SettledFile { get; set; }
            public string UnsettledFile { get; set; }
            public double HighWinRateThreshold { get; set; }
        }
    }
}