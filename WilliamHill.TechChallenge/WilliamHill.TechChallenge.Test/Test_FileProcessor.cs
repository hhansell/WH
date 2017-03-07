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
            mConfig = new TechChallengeConfig();
            mConfig.SettledFile = System.IO.Path.Combine(Environment.CurrentDirectory, "TestData", "Settled.csv");
            mConfig.UnsettledFile = System.IO.Path.Combine(Environment.CurrentDirectory, "TestData", "Unsettled.csv");
        }

        [TestMethod]
        public void Test_FileProcessor_Init_Success()
        {
            var fileProcessor = new FileProcessor(mConfig);
        }

        [TestMethod,ExpectedException(typeof(ArgumentNullException))]
        public void Test_FileProcessor_MissingConfig_Failure()
        {
            mConfig = new TechChallengeConfig();
            var fileProcessor = new FileProcessor(mConfig);
        }

        [TestMethod]
        public void Test_FileProcessor_Run_Success()
        {
            var fileProcessor = new FileProcessor(mConfig);
            fileProcessor.Run();
        }
    }
}