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

            // Added data hero for display
            new Hero()
            {
                name= "Captain America",
                power="Strength from gamma radiation",
                stats=
                new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 100 ),
                    new KeyValuePair<string, int>( "intelligence", 100),
                    new KeyValuePair<string, int>( "stamina", 100 )
                }
            }
        };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id)
        {
            return heroes.FirstOrDefault();
        }

        public void Post(string name, string action = null)
        {
            if (action == "evolve")
            {
                Hero hero = heroes.Where(h => h.name == name).FirstOrDefault();
                hero.evolve();
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
