using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InterviewTest.Models;
using InterviewTest.Interface;
using InterviewTest.viewModels;

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
                   name= "Iron Man",
                   power="Iron Mans's Armor",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 1000 ),
                       new KeyValuePair<string, int>( "intelligence", 200),
                       new KeyValuePair<string, int>( "stamina", 1500 )
                   }
               },
               new Hero()
               {
                   name= "Spider Man",
                   power="spider powers",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 1000 ),
                       new KeyValuePair<string, int>( "intelligence", 200),
                       new KeyValuePair<string, int>( "stamina", 1500 )
                   }
               },
               new Hero()
               {
                   name= "Thor",
                   power="God of Thunder & Lightning",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 900 ),
                       new KeyValuePair<string, int>( "intelligence", 60),
                       new KeyValuePair<string, int>( "stamina", 1000 )
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
        public IActionResult Post([FromBody] GetHeroViewModel model)
        {
            if (!string.IsNullOrEmpty(model.HeroName))
            {
                var hero = heroes.FirstOrDefault(x => x.name == model.HeroName);
                if (hero != null)
                {
                    hero.evolve();
                    return Ok(hero);
                }
            }
            
            return NoContent();
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
