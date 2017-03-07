using System;
using System.Configuration;
using System.Linq;

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

        public string SettledFile { get; set; }
        public string UnsettledFile { get; set; }
        public double HighWinRateThreshold { get; set; }
        public void Validate()
        {

            if (HighWinRateThreshold == 0) throw new ConfigurationErrorsException(nameof(HighWinRateThreshold));
        }

        private void LoadConfig()
        {
            HighWinRateThreshold = int.Parse(System.Configuration.ConfigurationManager.AppSettings.Get("HighWinRateThreshold"));
        }

      
    }
}