namespace WilliamHill.TechChallenge.Interfaces
{
    public interface ITechChallengeConfig
    {
        string SettledFile { get; set; }
        string UnsettledFile { get; set; }
        double HighWinRateThreshold { get; set; }
        double StakeMultiplierThreshold { get; set; }
        double HighStakeMultiplierThreshold { get; set; }
        double HighWinningTreshold { get; set; }
    }
}