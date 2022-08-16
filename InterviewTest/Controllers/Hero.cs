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
            //The `evolve` method on the class should increment all stats of the hero with a multiple of half the original stat value.            for (int i = 0; i < stats.Count; i++)
            {
                int iniValue = (stats[i].Value);
                int v = iniValue / statIncrease;
                int newVal = v * iniValue;

                var newKvp = new KeyValuePair<string, int>(stats[i].Key, newVal);

                stats.RemoveAt(i);
                stats.Insert(i, newKvp);
            }
        }

    }
}
