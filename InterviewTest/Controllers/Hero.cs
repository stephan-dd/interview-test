using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Interfaces;

namespace InterviewTest.Controllers
{
    public class Hero:IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public List<KeyValuePair<string, int>> statsNew { get; set; }
        public void evolve(int statIncrease = 5)
        {
            KeyValuePair<string, int> newEntry = new KeyValuePair<string, int>();
            statsNew = new List<KeyValuePair<string, int>>();
            foreach (var stat in stats)
            {
                var halfValue = stat.Value / 2;
                var newStatValue = stat.Value * halfValue;
                var statIncreasedValue = newStatValue.ToString();
                newEntry =  new KeyValuePair<string, int>(stat.Key, Convert.ToInt32(statIncreasedValue));
                statsNew.Add(newEntry);
            }
            //stats.Clear();
           
        }
    }
}
