using System;
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
            return File.ReadLines(fileName).SelectMany(line => line.Split(',')).Skip(1).Select(columns =>
                new Bet()
                {
                    Customer = columns[0],
                    Event = columns[1],
                    Participant = columns[2],
                    Stake = columns[3],
                    Win = columns[4]
                });
        }
    }
}