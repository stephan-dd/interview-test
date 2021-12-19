using System.Collections.Generic;

namespace InterviewTest.Controllers
{

    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public void evolve(int statIncrease = 5)
        {
            List<KeyValuePair<string, int>> newStats = new List<KeyValuePair<string, int>>();

            foreach (var stat in stats ?? new List<KeyValuePair<string, int>>())
            {
                // update stat

                // assumed statIncrease is for increase of factor of base (half of current)
                var newValue = ((stat.Value * 0.5) * statIncrease) + stat.Value;

                // add stat to new array
                newStats.Add(new KeyValuePair<string, int>(stat.Key, (int)System.Math.Floor(newValue)));
            }

            // assign new stats list to stats
            stats = newStats;
        }
    }
}
