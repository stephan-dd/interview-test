using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{

    public class Action
    {
        public string name { get; set; }
        public string action { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private Hero[] heroes = new Hero[] {
               new Hero()
               {
                   name = "Hulk",
                   power ="Strength from gamma radiation",
                   stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               },
               new Hero()
               {
                   name = "Superman",
                   power ="Faster than a speeding bullet",
                   stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 4000 ),
                       new KeyValuePair<string, int>( "intelligence", 60),
                       new KeyValuePair<string, int>( "stamina", 3500 )
                   }
               },
               new Hero()
               {
                   name = "Batman",
                   power ="Rich playboy",
                   stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 2000 ),
                       new KeyValuePair<string, int>( "intelligence", 90),
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
        public Hero Post([FromBody] Action hero)
        {
            var query = this.heroes.Where(item => item.name == hero.name);          

                if (hero.action == "evolve")
                {
                    Hero selectedHero = query.FirstOrDefault();
                    selectedHero.evolve();

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
