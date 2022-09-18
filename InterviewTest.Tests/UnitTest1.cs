using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace InterviewTest.Tests
{
    public class UnitTest1
    {
        List<KeyValuePair<string, double>> stats { get; set; }
        List<KeyValuePair<string, double>> ogStats { get; set; }
        [Fact]
        public void HeroCanEvolve()
        {
            stats = new List<KeyValuePair<string, double>>();
            stats.Add(new KeyValuePair<string, double>("heat vision", 10));
            stats.Add(new KeyValuePair<string, double>("super strength", 5));
            ogStats = new List<KeyValuePair<string, double>>(stats);

            foreach (var ogStat in ogStats)
            {
                stats[ogStats.IndexOf(ogStat)] = new KeyValuePair<string, double>(ogStat.Key, ogStat.Value * 0.5 + stats.FirstOrDefault(stat => stat.Key == ogStat.Key).Value);
            }
        }
    }
}
