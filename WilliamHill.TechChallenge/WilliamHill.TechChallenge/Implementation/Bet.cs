namespace WilliamHill.TechChallenge.Implementation
{
    /// <summary>
    /// This model describes the Bet object
    /// </summary>
    public class Bet
    {
        public int Customer { get; set; }
        public int Event { get; set; }
        public int Participant { get; set; }
        public int Stake { get; set; }
        public int Win { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return $"Customer [{Customer}] Event [{Event}] Participant [{Participant}] Stake [{Stake}]";
        }

        #endregion
    }
}