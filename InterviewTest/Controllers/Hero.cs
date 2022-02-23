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
        public string action { get; set; }

        //Evolve POST tested in PostMan
        // Changed C# code to increment with double value for more precise increments
        public void evolve(double statIncrease = 0.5)
        {
            foreach (KeyValuePair<string, int> stat in stats.ToList())
                if (stats.Contains(stat))
                {
                    int i = stats.IndexOf(stat);
                    KeyValuePair<string, int> newValue = new KeyValuePair<string, int>(stat.Key, (int)(stat.Value + stat.Value * statIncrease));
                    stats[i] = newValue;
                }
        }
    }
}
