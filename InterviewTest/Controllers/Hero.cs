using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public interface IHero 
    {
        string name { get; set; }
        string power { get; set; }
        List<KeyValuePair<string, int>> stats { get; set; }
        void evolve();
    }
    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public void evolve()
        {
            foreach (KeyValuePair<string, int> Stat in stats.ToList())
            {
                int OldStat = stats.RemoveAll(x => x.Key == Stat.Key);

                if (OldStat == 1)
                {
                    int NewValue = Stat.Value + (Stat.Value / 2);
                    stats.Add(new KeyValuePair<string, int>(Stat.Key, NewValue));
                }

            }

        }
    }
}
