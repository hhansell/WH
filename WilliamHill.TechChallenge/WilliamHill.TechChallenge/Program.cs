using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WilliamHill.TechChallenge.Implementation;

namespace WilliamHill.TechChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            ITechChallengeConfig config = new TechChallengeConfig();
            if (config == null) throw new ArgumentNullException(nameof(config));
            
        }
    }
}
