using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.BusinessLogic
{
    public class Hero : IHero
    {
        public string Name { get; set; }
        public string Power { get; set; }
        public List<KeyValuePair<string, int>> Stats { get; set; }
        public void Evolve(int statIncrease = 5)
        {
            var halfOfOriginalStat = Stats.FirstOrDefault().Value / 2;
            var multiple = NumberProcessor.GetMultiple(halfOfOriginalStat);
            var newStats = new List<KeyValuePair<string, int>>();

            foreach(var (key, value) in Stats)
            {
                newStats.Add(new KeyValuePair<string, int>(key, value + multiple));
            }
            Stats = newStats;
        }
    }
}
