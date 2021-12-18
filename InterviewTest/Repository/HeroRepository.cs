using InterviewTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Repository
{
    public class HeroRepository : IHero
    {
        public void Evolve(Hero hero, int statIncrease = 5)
        {
            int calculation = statIncrease == 0 ? 5 : statIncrease / 2;

            for (int i = 0; i < hero.Stats.Count(); i++)
            {
                var stats = hero.Stats[i];
                hero.Stats[i] = new KeyValuePair<string, int>(stats.Key, (stats.Value * calculation));
            }
        }

        public IEnumerable<Hero> GenerateHeroData()
        {
            return new List<Hero>
            {
                new Hero
               {
                   Name= "Hulk",
                   Power="Strength from gamma radiation",
                   Stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               }
            };
        }
    }
}
