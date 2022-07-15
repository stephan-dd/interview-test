using InterviewTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Services
{
    public class HeroService : IHeroService
    {
        private readonly HeroContext _data;

        public HeroService(HeroContext data)
        {
            _data = data;
        }

        public Hero Evolve(string heroName)
        {
            //
            var heroToEvolve = GetHeroByName(heroName);

            if (heroToEvolve != null)
            {
                var newStats = new List<KeyValuePair<string, int>>();

                foreach (var stat in heroToEvolve.Stats)
                {
                    //Evolve Hero Stats
                    newStats
                        .Add
                        (
                            new KeyValuePair<string, int>(stat.Key, stat.Value * (stat.Value / 2))
                        );
                }
                // Update Hero Stats
                heroToEvolve.Stats = newStats;

                return heroToEvolve;
            }
            return null;
        }

        public Hero GetHeroByName(string name)
        {
            return _data.heroes.FirstOrDefault(x => x.Name == name);
        }

        public Hero[] GetHeroList()
        {
            return _data.heroes;
        }
    }
}
