using InterviewTest.Models;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTest.Data
{
    public class HeroRepository : IHeroRepository
    {
        public HeroModel[] GetHeroes()
        {
            var heroes = Heroes().ToArray();

            return heroes;
        }

        public HeroModel GetById(int id)
        {
            var hero = Heroes().FirstOrDefault(x => x.Id.Equals(id));

            return hero;
        }

        public HeroModel GetByName(string name)
        {
            var hero = Heroes().FirstOrDefault(x => x.Name.Equals(name));

            return hero;
        }

        private List<HeroModel> Heroes()
        {
            var heroes = new List<HeroModel>
            {
                new HeroModel()
                {
                   Id = 1,
                   Name = "Hulk",
                   Power = "Strength from gamma radiation",
                   Stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
                }
            };

            return heroes;
        }
    }
}
