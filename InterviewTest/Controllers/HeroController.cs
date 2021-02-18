using System.Collections.Generic;
using System.Linq;
using InterviewTest.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHero[] _heroes = {
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

        [HttpGet]
        [Route("api/v1/[controller]/AllHeroes")]
        public IEnumerable<IHero> Get()
        {
            return _heroes;
        }

        [HttpGet("{id}", Name = "Get")]
        public IHero Get(int id)
        {
            return _heroes.FirstOrDefault();
        }

        [HttpPost]
        [Route("api/v1/[controller]/EvolveAllHeroes")]
        public IEnumerable<IHero> Post(bool evolve)
        {
            if (!evolve) return _heroes;
            _heroes.ToList().ForEach(hero =>
            {
                hero.Evolve(); 
            });

            return _heroes;
        }
    }
}
