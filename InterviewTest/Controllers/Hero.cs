using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero: IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public void evolve(int statIncrease = 5)
        {
            List<KeyValuePair<string, int>> statsUpdated = new List<KeyValuePair<string, int>>(); 
            stats.ForEach(delegate(KeyValuePair<string, int> stat){
                string key = stat.Key;
                decimal statVal = (decimal)stat.Value;
                int statValHalf = (int)Math.Truncate(statVal / 2);
                statsUpdated.Add(new KeyValuePair<string, int>(key, statValHalf));
            });
            stats = statsUpdated;
        }
    }
}
