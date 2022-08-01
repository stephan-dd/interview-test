using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Interfaces;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        //Full Properities Format
        private string name;
        private string power;
        private List<KeyValuePair<string, int>> stats;

        public string Name { get { return name; } set { name = value; } }
        public string Power { get { return power; } set { power = value; } }
        public List<KeyValuePair<string, int>> Stats { get { return stats; } set { stats = value; } }

        public void evolve(int statIncrease = 5)
        {
            List<KeyValuePair<string, int>> newStats = new List<KeyValuePair<string, int>>();

            this.Stats.ForEach(stat => {
                newStats.Add(new KeyValuePair<string, int>(stat.Key, stat.Value * 5));
            });

            this.Stats = newStats;
        }
    }
}
