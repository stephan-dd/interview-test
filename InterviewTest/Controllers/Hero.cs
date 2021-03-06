using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public interface IHero 
    {
        string Name { get; set; }
        string Power { get; set; }
        List<KeyValuePair<string, int>> Stats { get; set; }
        void Evolve();
    }
    public class Hero : IHero
    {
        public string Name { get; set; }
        public string Power { get; set; }
        public List<KeyValuePair<string, int>> Stats {get;set;}
        public void Evolve()
        {
            foreach (KeyValuePair<string, int> Stat in Stats.ToList())
            {
                int OldStat = Stats.RemoveAll(x => x.Key == Stat.Key);

                if (OldStat == 1)
                {
                    int NewValue = Stat.Value + (Stat.Value / 2);
                    Stats.Add(new KeyValuePair<string, int>(Stat.Key, NewValue));
                }

            }

        }
    }
}
