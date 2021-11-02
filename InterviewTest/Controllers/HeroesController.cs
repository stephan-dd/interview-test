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

        private readonly IHero hero;
        public HeroesController( IHero _hero)
        {
            hero = _hero;
        }
        private Hero[] heroes = new Hero[] {
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
                   name= "IronMan",
                   power="Strength from Steal suit",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 300 ),
                       new KeyValuePair<string, int>( "intelligence", 5000),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               },

                  new Hero()
               {
                   name= "SuperMan",
                   power="Strength born with it",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 100000 ),
                       new KeyValuePair<string, int>( "intelligence", 100000),
                       new KeyValuePair<string, int>( "stamina", 50000 )
                   }
               },
                  new Hero()
               {
                   name= "Spider Man",
                   power="Strength from spider",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 10000 ),
                       new KeyValuePair<string, int>( "intelligence", 100000),
                       new KeyValuePair<string, int>( "stamina", 2000 )
                   }
               }
            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return this.heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id)
        {
            return this.heroes.FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public Hero[] Post([FromBody] Hero heroData = null)
        {
            return hero.evolve(heroData);
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
