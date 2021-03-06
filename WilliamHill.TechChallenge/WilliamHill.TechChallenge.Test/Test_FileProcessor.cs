﻿using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Test
{
    [TestClass]
    public class Test_FileProcessor
    {
        private ITechChallengeConfig mConfig;

        [TestInitialize]
        public void Test_Initialize()
        {
            var settledFile = Path.Combine(Environment.CurrentDirectory, "TestData", "Settled.csv");
            var unsettledFile = Path.Combine(Environment.CurrentDirectory, "TestData", "Unsettled.csv");
            mConfig = new TestConfig {SettledFile = settledFile, UnsettledFile = unsettledFile};
        }

        [TestMethod]
        public void Test_FileProcessor_Load_Success()
        {
            var settledBets = FileProcessor.LoadFile(mConfig.SettledFile);
            var unsettledBets = FileProcessor.LoadFile(mConfig.UnsettledFile);
            Assert.IsTrue(settledBets.Any(), "No settled bets were loaded!");
            Assert.IsTrue(unsettledBets.Any(), "No unsettled bets were loaded!");
        }

        #region Nested type: TestConfig

        private class TestConfig : ITechChallengeConfig
        {
            #region ITechChallengeConfig Members

            public string SettledFile { get; set; }
            public string UnsettledFile { get; set; }
            public double HighWinRateThreshold { get; set; }
            public double StakeMultiplierThreshold { get; set; }
            public double HighStakeMultiplierThreshold { get; set; }
            public double HighWinningTreshold { get; set; }

            #endregion
        }

        #endregion
    }
}