using InterviewTest.Data;
using InterviewTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Services
{
    public class Hero : IHero
    {
        private readonly IHeroRepository _heroRepository;

        public Hero(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        public HeroModel Evolve(string name, string action, int statIncrease = 5)
        {
            var hero = _heroRepository.GetByName(name);

            if (action.Equals("none"))
                return hero;

            var evolvedStats = new List<KeyValuePair<string, int>>();

            foreach (var stat in hero.Stats)
            {
                var multipleOfHalf = ((stat.Value / 2) * statIncrease);
                var incrementedValue = stat.Value + multipleOfHalf;
                var incrementedStat = new KeyValuePair<string, int>(stat.Key, incrementedValue);
                evolvedStats.Add(incrementedStat);
            }

            hero.Stats.Clear();
            hero.Stats.AddRange(evolvedStats);

            return hero;
        }

        public HeroModel[] GetHeroes()
        {
            var heroes = _heroRepository.GetHeroes();

            return heroes;
        }

        public HeroModel GetById(int heroId)
        {
            var hero = _heroRepository.GetById(heroId);

            return hero;
        }

        public HeroModel GetByName(string name)
        {
            var hero = _heroRepository.GetByName(name);

            return hero;
        }
    }
}
