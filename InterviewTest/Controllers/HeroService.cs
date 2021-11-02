using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class HeroService : IHero
    {
        public Hero[] evolve(Hero hero)
        {
            try
            {
                List<KeyValuePair<string, int>> updatedStats = new List<KeyValuePair<string, int>>();

                hero.stats.ForEach(x =>
                {
                    updatedStats.Add(new KeyValuePair<string, int>(x.Key, (x.Value / 2) + x.Value));
                });

                hero.stats = updatedStats;

                return new Hero[] { hero } ;
            }
            catch (Exception)
            {
                throw new Exception("Please check if the Hero is not null");
            }

        }

    }
}
