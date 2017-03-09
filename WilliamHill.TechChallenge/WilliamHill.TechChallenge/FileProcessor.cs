using System.Collections.Generic;
using System.IO;
using System.Linq;
using WilliamHill.TechChallenge.Implementation;

namespace WilliamHill.TechChallenge
{
    public class FileProcessor
    {
        public static IEnumerable<Bet> LoadFile(string fileName)
        {
            // load up a csv, skip the first line containing headings, parse into a bet model
            return File.ReadLines(fileName).Skip(1).Select(line => line.Split(',')).Select(columns => new Bet {Customer = int.Parse(columns[0]), Event = int.Parse(columns[1]), Participant = int.Parse(columns[2]), Stake = int.Parse(columns[3]), Win = int.Parse(columns[4])});
        }
    }
}