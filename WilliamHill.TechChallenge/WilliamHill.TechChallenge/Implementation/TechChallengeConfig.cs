using System;
using System.Configuration;
using WilliamHill.TechChallenge.Interfaces;

namespace WilliamHill.TechChallenge.Implementation
{
    public class TechChallengeConfig : ITechChallengeConfig
    {
        public TechChallengeConfig(string settledFileName, string unsettledFileName)
        {
            if (settledFileName == null) throw new ArgumentNullException(nameof(settledFileName));
            if (unsettledFileName == null) throw new ArgumentNullException(nameof(unsettledFileName));

            SettledFile = settledFileName;
            UnsettledFile = unsettledFileName;

            LoadConfig();
            Validate();
        }

        #region ITechChallengeConfig Members

        public string SettledFile { get; set; }
        public string UnsettledFile { get; set; }
        public double HighWinRateThreshold { get; set; }
        public double StakeMultiplierThreshold { get; set; }
        public double HighWinningTreshold { get; set; }
        public double HighStakeMultiplierThreshold { get; set; }

        #endregion

        public void Validate()
        {
            if (HighWinRateThreshold == 0) throw new ConfigurationErrorsException(nameof(HighWinRateThreshold));
            if (StakeMultiplierThreshold == 0) throw new ConfigurationErrorsException(nameof(StakeMultiplierThreshold));
            if (HighStakeMultiplierThreshold == 0) throw new ConfigurationErrorsException(nameof(HighStakeMultiplierThreshold));
            if (HighWinningTreshold == 0) throw new ConfigurationErrorsException(nameof(HighWinningTreshold));
        }

        private void LoadConfig()
        {
            HighWinRateThreshold = double.Parse(ConfigurationManager.AppSettings.Get("HighWinRateThreshold"));
            StakeMultiplierThreshold = double.Parse(ConfigurationManager.AppSettings.Get("StakeMultiplierThreshold"));
            HighStakeMultiplierThreshold = double.Parse(ConfigurationManager.AppSettings.Get("HighStakeMultiplierThreshold"));
            HighWinningTreshold = double.Parse(ConfigurationManager.AppSettings.Get("HighWinningTreshold"));
        }
    }
}