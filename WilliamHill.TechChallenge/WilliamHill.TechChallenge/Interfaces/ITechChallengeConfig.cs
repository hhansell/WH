namespace WilliamHill.TechChallenge
{
    public interface ITechChallengeConfig
    {
        string SettledFile { get; set; }
        string UnsettledFile { get; set; }
        double HighWinRateThreshold { get; set; }
    }
}