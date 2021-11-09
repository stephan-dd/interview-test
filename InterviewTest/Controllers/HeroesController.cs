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
        private readonly Hero[] heroes = new Hero[] {
               new Hero()
               {
                   Name = "Hulk",
                   Power = "Strength from gamma radiation",
				   Stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "Strength", 5000 ),
                       new KeyValuePair<string, int>( "Intelligence", 50),
                       new KeyValuePair<string, int>( "Stamina", 2500 )
                   }
               },

               new Hero()
               {
                   Name = "Shaktimaan",
                   Power = "Strength from gamma radiation",
                   Stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "Strength", 2500 ),
                       new KeyValuePair<string, int>( "Intelligence", 25),
                       new KeyValuePair<string, int>( "Stamina", 1250 )
                   }
               },

               new Hero()
               {
                   Name = "Krrish",
                   Power = "Strength from gamma radiation",
                   Stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "Strength", 1250 ),
                       new KeyValuePair<string, int>( "Intelligence", 12),
                       new KeyValuePair<string, int>( "Stamina", 625 )
                   }
               },

               new Hero()
               {
                   Name = "Ra-One",
                   Power = "Strength from gamma radiation",
                   Stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "Strength", 625 ),
                       new KeyValuePair<string, int>( "Intelligence", 6),
                       new KeyValuePair<string, int>( "Stamina", 312 )
                   }
               },
                new Hero()
               {
                   Name = "Nagraj",
                   Power = "Strength from gamma radiation",
                   Stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "Strength", 3000 ),
                       new KeyValuePair<string, int>( "Intelligence", 30),
                       new KeyValuePair<string, int>( "Stamina", 1500 )
                   }
               },
                new Hero()
               {
                   Name = "Veer the Robot Boy",
                   Power = "Strength from gamma radiation",
                   Stats =
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "Strength", 1500 ),
                       new KeyValuePair<string, int>( "Intelligence", 15),
                       new KeyValuePair<string, int>( "Stamina", 750 )
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
        public Hero Post([FromBody] Hero hero, string value = "none")
        {
            if (hero.Action.ToLower() == "evolve")
                hero.Evolve(2);

            return hero;
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
