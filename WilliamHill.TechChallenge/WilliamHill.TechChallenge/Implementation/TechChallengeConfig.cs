namespace WilliamHill.TechChallenge.Implementation
{
    public class TechChallengeConfig : ITechChallengeConfig
    {
        public string SettledFile { get; set; }
        public string UnsettledFile { get; set; }
        public double HighWinRateThreshold { get; set; }
    }
}