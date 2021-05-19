using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {

        private static Hero[] heroes = new Hero[] {
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
               },
               new Hero()
               {
                   name= "Iron Man",
                   power="Tech Suite and Armor",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 200 ),
                       new KeyValuePair<string, int>( "intelligence", 4000),
                       new KeyValuePair<string, int>( "stamina", 1000 )
                   }
               }
            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            foreach (var hero in heroes)
            {
                hero.stats = hero.stats.GroupBy(x => x.Key).Select(g => g.Last()).ToList();
            }
            return heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id)
        {
            return heroes.FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public ActionResult Post([FromBody] HeroEvolveRequest heroEvolveRequest)
        {
            if (heroEvolveRequest.ActionName == "evolve")
            {
                var hero = heroes.Where(h => h.name == heroEvolveRequest.HeroName).FirstOrDefault();
                if (hero != null)
                {
                    hero.evolve();
                    Hero evolvedHero = new Hero
                    {
                        name = hero.name,
                        power = hero.power,
                        stats = hero.stats.GroupBy(x => x.Key).Select(g => g.Last()).ToList()
                    };
                    return Ok(evolvedHero);
                }
            }
            return BadRequest();
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
