using InterviewTest.Models;
using InterviewTest.Repository.Interface;
using InterviewTest.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Services
{
    public class HeroService : IHeroService
    {
        private IHeroRepository _repository;

        public HeroService(IHeroRepository repository)
        {
            _repository = repository;
        }

        public List<Hero> GetHeroes()
        {
            return _repository.GetHeroes();
        }

        public void Update(Hero hero)
        {
            hero.evolve();
            _repository.Update(hero);
        }
    }
}
