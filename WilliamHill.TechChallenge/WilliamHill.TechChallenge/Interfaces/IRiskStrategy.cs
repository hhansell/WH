using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.TechChallenge.Implementation;

namespace WilliamHill.TechChallenge.Interfaces
{
    /// <summary>
    /// Evaluate a given set of bets against a risk strategy
    /// </summary>
    interface IRiskStrategy
    {
        /// <summary>
        /// Evaluates the current risk strategy for the specified bets.
        /// </summary>
        /// <param name="settledBets">The settled bets.</param>
        /// <param name="unsettledBets">The unsettled bets.</param>
        /// <returns>Any alerts raised through the evaluation</returns>
        IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets);
    }
}
