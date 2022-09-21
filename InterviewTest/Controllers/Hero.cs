using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public void evolve(int increaseStats = 5)
        {
            for (int i = 0; i < stats.Count; i++)
            {
                int startVal = stats[i].Value;
                int halfVal = startVal / increaseStats;
                int resultVal = halfVal * startVal;

                var keyPairs = new KeyValuePair<string, int>(stats[i].Key, resultVal);

                stats.RemoveAt(i);
                stats.Insert(i, keyPairs);
            }
        
        }
    }
}
