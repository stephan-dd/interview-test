using InterviewTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public void evolve(int statIncrease = 5)
        {
            for (int i = 0; i < this.stats.Count; i++)
            {
                this.stats[i] = new KeyValuePair<string, int>(stats[i].Key, (int)(stats[i].Value + (0.5 * stats[i].Value)));
            }

        }
    }
}
