using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest
{
    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public void evolve(int statIncrease = 5)
        {
            var diction = new List<KeyValuePair<string, int>>();
            foreach(KeyValuePair<string,int> kvp in stats)
            {
                var newVal = kvp.Value + kvp.Value * 1 / 2;
                var newEntry = new KeyValuePair<string, int>(kvp.Key, newVal);
                var removeOldItem = stats.Where(x => x.Key == kvp.Key).SingleOrDefault();
                diction.Add(newEntry);
            }

            stats = diction;
        }
    }
}
