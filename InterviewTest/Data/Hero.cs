using System;
using System.Collections.Generic;
using InterviewTest.Entity;

namespace InterviewTest.Data
{
    public class Hero : AppHero
    {
        public void Evolve(int statIncrease = 5)
        {
            List<KeyValuePair<string, int>> newStats = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> stat in stats)
            {
                newStats.Add(new KeyValuePair<string, int>(stat.Key, Convert.ToInt32((stat.Value / 2)) * statIncrease));
            }
            this.stats = newStats;
        }

    }
}
