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
        public void evolve(int statIncrease = 5)
        {
            List<KeyValuePair<string, int>> initialStats = new List<KeyValuePair<string, int>>();
            //Get the initial stats list, they are the first of each stat type
            foreach (var stat in stats)
            {
                var matchingstats = initialStats.Where(x => x.Key.Equals(stat.Key)).ToList();
                //if failed then prove
                if (matchingstats.Count == 0)
                {
                    initialStats.Add(stat);
                }
            }

            List<KeyValuePair<string, int>> updateStats = new List<KeyValuePair<string, int>>();

            //With list of initial stats we can evolve the stats
            foreach (var stat in stats)
            {
                //get the single stat with the unique key
                var initialStat = initialStats.Single(x => x.Key.Equals(stat.Key));

                //Evolve by creating the new stat
                var statupdate = new KeyValuePair<string, int>(stat.Key, stat.Value + (initialStat.Value / 2));

                //Update to new list
                updateStats.Add(statupdate);
            }

            stats = updateStats;
        }
    }
}
