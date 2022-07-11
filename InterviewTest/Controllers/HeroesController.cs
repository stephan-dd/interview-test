using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private IHero[] heroes = new Hero[] {
               new Hero()
               {
                   name= "Hulk",
                   power="Strength from gamma radiation",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               }
            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<IHero> Get()
        {
            return this.heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public IHero Get(int id)
        {
            return this.heroes.FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public IHero Post([FromBody] Hero hero = null)
        {
            // API - The post method should read an action parameter
            // which defaults to none if the action is evolve
            // it should evolve the hero and return the hero with its new stats.

            Hero superHero = new Hero();
            superHero.evolve();

            hero.stats = superHero.stats;
            return hero;
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public IHero Put(int id, [FromBody] Hero hero)
        {
            // Evolve the hero and return the hero with its new stats.

            Hero superHero = new Hero();
            superHero.stats = hero.stats;
            superHero.evolve();

            hero.stats = superHero.stats;
            return hero;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
