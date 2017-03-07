using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.TechChallenge.Implementation;

namespace WilliamHill.TechChallenge.Interfaces
{
    interface IRiskMetrics
    {
        int[] GetHighWinRates(IEnumerable<Bet> settledBets);
    }
}
