using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.TechChallenge.Implementation;

namespace WilliamHill.TechChallenge.Interfaces
{
    interface IRiskStrategy
    {
        IEnumerable<string> Evaluate(IEnumerable<Bet> settledBets, IEnumerable<Bet> unsettledBets);
    }
}
