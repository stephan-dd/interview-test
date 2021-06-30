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
                   name= "Superman",
                   power="X-ray Vision",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "intelligence", 20),
                       new KeyValuePair<string, int>( "stamina", 1000 ),
                       new KeyValuePair<string, int>( "strength", 4000 )
                   },
               },
               new Hero()
               {
                   name= "Captain America",
                   power="Healing ability and expert tactician",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2000 ),
                       new KeyValuePair<string, int>( "strength", 3500 )
                   },
               },
               new Hero()
               {
                   name= "Iron Man",
                   power="Genius-level intellect",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "intelligence", 200),
                       new KeyValuePair<string, int>( "stamina", 4000 ),
                       new KeyValuePair<string, int>( "strength", 2500 )
                   },
               },
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
        public Hero Post([FromBody] Action action)
        {
            if (action.action == "evolve")
            {
                Hero selectedHero = heroes.FirstOrDefault(e => e.name == action.heroName);
                selectedHero.evolve(50);
                return selectedHero;
            }
            else
            {
                return null;
            }
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
