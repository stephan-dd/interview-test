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
        public List<KeyValuePair<string, int>> stats { get; set; }
        public void evolve(int statIncrease = 5)
        {
            for (int _x = 0; _x < stats.Count; _x++)
            {
                if (stats[_x].Value % 2 == 0)
                {
                    int value = Convert.ToInt32(stats[_x].Value + (stats[_x].Value / 2));
                    stats[_x] = new KeyValuePair<string, int>(stats[_x].Key, value);
                }
            }            
        }
    }
}





