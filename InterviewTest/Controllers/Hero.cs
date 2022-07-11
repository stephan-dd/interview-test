using InterviewTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    // API - Refactor the Hero class to implement an interface of IHero.
    public class Hero : IHero
    {
        public int id { get; set; }
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }
        public void evolve(int statIncrease = 5)
        {
            // API - The evolve method on the class should increment all stats
            // of the hero with a multiple of half the original stat value.
            for (int i = 0; i < stats.Count; i++)
            {
                var originalValue = (stats[i].Value);
                int value = originalValue / statIncrease;
                int newValue = value * originalValue;

                var newKayValuePair = new KeyValuePair<string, int>(stats[i].Key, newValue);
                stats.RemoveAt(i);
                stats.Insert(i, newKayValuePair);
            }
        }
    }
}
