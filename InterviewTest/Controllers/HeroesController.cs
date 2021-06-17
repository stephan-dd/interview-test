using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InterviewTest.Extensions;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
       private static IHero[] modifiedHeroes = null;

        private IHero[] heroes = new Hero[] {
               new Hero()
               {
                   name= "Hulk",
                   power="Strength from gamma radiation",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500)
                   }
               },
                new Hero()
               {
                   name= "Super Man",
                   power="Strength to fly",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 10000),
                       new KeyValuePair<string, int>( "intelligence", 100),
                       new KeyValuePair<string, int>( "stamina", 5000)
                   }
               },
                new Hero()
               {
                   name= "IronMan",
                   power="Strength from technology",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 7000),
                       new KeyValuePair<string, int>( "intelligence", 80),
                       new KeyValuePair<string, int>( "stamina", 4000)
                   }
               },
                new Hero()
               {
                   name= "SpiderMan",
                   power="Strength from spider web",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 6000),
                       new KeyValuePair<string, int>( "intelligence", 70),
                       new KeyValuePair<string, int>( "stamina", 3000)
                   }
               }
            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<IHero> Get()
        {
            if(modifiedHeroes != null)
                return modifiedHeroes;

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
        public IHero Post([FromBody] Hero hero)
        {
            var heroesArray = modifiedHeroes == null ? this.heroes : modifiedHeroes;

            var heroToChange = heroesArray.Where(h => h.name == hero.name).FirstOrDefault();

            if (hero != null){

                if(hero.stats != null)
                {
                    var newStats = heroToChange.evolve(hero);


                    heroToChange = heroToChange.ApplyNewStatsToList(hero,newStats);

                        if(modifiedHeroes == null)
                            modifiedHeroes =this.heroes;

                }

             }
             return heroToChange;
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] IHero value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
