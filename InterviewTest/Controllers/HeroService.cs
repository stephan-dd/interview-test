using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class HeroService : IHero
    {
        public Hero evolve(Hero hero, int statIncrease = 5)
        {
            List<KeyValuePair<string, int>> updatedStats = new List<KeyValuePair<string, int>>();
           
            hero.stats.ForEach(x =>
            {
                updatedStats.Add( new KeyValuePair<string, int>(x.Key,x.Value * statIncrease));
            });

            hero.stats = updatedStats;

            return hero;
        }

    }
}
