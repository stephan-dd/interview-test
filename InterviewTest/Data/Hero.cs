using System;
using System.Collections.Generic;


namespace InterviewTest.Data
{
    public class Hero
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }
        public void evolve(int statIncrease = 5)
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
