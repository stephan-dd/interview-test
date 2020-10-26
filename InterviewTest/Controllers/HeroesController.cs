using System.Collections.Generic;
using System.Linq;
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
               }
            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return this.heroes;
        }

        // GET: api/Heroes/hulk
        [HttpGet("{name}", Name = "Get")]
        public Hero Get(string name)
        {
            return this.heroes.FirstOrDefault(x => string.Equals(x.name, name, System.StringComparison.InvariantCultureIgnoreCase));
        }

        // POST: api/Heroes
        [HttpPost("{name}")]
        public Hero Post(string name, [FromBody] PostInput input = null) //hero name
        {
            var hero = this.heroes.FirstOrDefault(x => string.Equals(x.name, name, System.StringComparison.InvariantCultureIgnoreCase));

            if (hero != null && string.Equals(input.action, "evolve", System.StringComparison.InvariantCultureIgnoreCase))
            {
                hero.evolve();
                return hero;
            }    

            return null;
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
