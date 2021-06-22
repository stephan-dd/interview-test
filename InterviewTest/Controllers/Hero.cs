using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero: IHero
    {
        /// <summary>
        /// Injects a data access helper needed by the evolve method
        /// </summary>
        /// 
        readonly IHeroUtilities _heroUtilities;
        public Hero(IHeroUtilities heroUtilities)
        {
            _heroUtilities = heroUtilities;
        }

        public Hero() { }

        public int id { get; set; }

        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public Hero evolve(int statIncrease)
        {
            var newStats = new List<KeyValuePair<string, int>>();
            var hero = _heroUtilities.GetHeroes().FirstOrDefault();

            foreach (var heroStat in hero.stats)
            {
                newStats.Add(adjustStat(statIncrease, heroStat));
            }
            return _heroUtilities.UpdateHeroStats(newStats);
        }

        /// <summary>
        /// Applies a formula for adjusting each stat. 
        /// </summary>
        /// <param name="statIncrease"></param>
        /// <param name="stat"></param>
        /// <returns></returns>
        private static KeyValuePair<string, int> adjustStat(int statIncrease, KeyValuePair<string, int> stat)
        {
            return new KeyValuePair<string, int>(stat.Key, statIncrease * (stat.Value / 2));
        }
    }
}
