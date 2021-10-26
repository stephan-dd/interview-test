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
                   power="Strength, durability and immortality from gamma radiation... Also very angry",
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
                   name= "SheHulk",
                   power="Strength, durability and immortality from gamma radiation... but not so angry, and she's a lady",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 4500 ),
                       new KeyValuePair<string, int>( "intelligence", 55),
                       new KeyValuePair<string, int>( "stamina", 3400 )
                   }
               },

               new Hero()
               {
                   name= "Thor",
                   power="God of thunder, practically immortal. Son of the Allfather, Odin",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 3000 ),
                       new KeyValuePair<string, int>( "intelligence", 25),
                       new KeyValuePair<string, int>( "stamina", 5000 )
                   }
               },

               new Hero()
               {
                   name= "Spiderman",
                   power="Ultimate parkour, webslinger, wall crawler, spider sense, and sassy teenage attitude. Also pretty smart",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 2000 ),
                       new KeyValuePair<string, int>( "intelligence", 45),
                       new KeyValuePair<string, int>( "stamina", 6000 )
                   }
               },
                new Hero()
               {
                   name= "Wolverine",
                   power="Super healing factor, shiny adamantium skeleton and claws. Usually has a fowl mouth and fowl mood to boot",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 1200 ),
                       new KeyValuePair<string, int>( "intelligence", 30),
                       new KeyValuePair<string, int>( "stamina", 100000 )
                   }
               },
                new Hero()
               {
                   name= "Deadpool",
                   power="Like Wolverine but without the claws and adamantium, but with a sense of 4th wall breaking humor and sward skillz",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 1201 ),
                       new KeyValuePair<string, int>( "intelligence", 31),
                       new KeyValuePair<string, int>( "stamina", 100001 )
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
            if (hero.action.ToLower() == "action")
                value = "action";

            if (value == "action")
                hero.evolve(0.5);

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
