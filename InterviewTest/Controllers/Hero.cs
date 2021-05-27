using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Interfaces;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }

        public void evolve(int statIncrease = 5)
        {
            List<KeyValuePair<string, int>> newValues = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> item in this.stats.ToList())
            {
                newValues.Add(new KeyValuePair<string, int>(item.Key, (int)(item.Value * 1.5)));
            }

            stats = newValues;
            
        }
    }
}
