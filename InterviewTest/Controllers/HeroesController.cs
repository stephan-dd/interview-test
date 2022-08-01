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
                   Name= "Hulk",
                   Power="Strength from gamma radiation",
                   Stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               },
               new Hero()
               {
                   Name= "Super Ant",
                   Power="Strength from muscle",
                   Stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 50000 ),
                       new KeyValuePair<string, int>( "intelligence", 150),
                       new KeyValuePair<string, int>( "stamina", 3500 )
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

        // POST: api/Heroes/heroName
        [HttpPost("{heroName}")]
        public Hero Post(string heroName, [FromQuery] string actions = "none")
        {
            if (actions == "evolve" && heroName != null)
            {
                Hero hero = this.heroes.FirstOrDefault(x=>x.Name.ToLower() == heroName.ToLower());
                hero.evolve();
                return hero;
            }
            return this.heroes.FirstOrDefault();
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
