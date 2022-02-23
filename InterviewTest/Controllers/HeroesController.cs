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
                       new KeyValuePair<string, int>( "Strength", 5000 ),
                       new KeyValuePair<string, int>( "Intelligence", 50),
                       new KeyValuePair<string, int>( "Stamina", 2500 )
                   }
               },
               new Hero() //Just added another 'Hero'
               {
                   name= "Iron Man",
                   power="Genius, Billionaire, Playboy philanthropist",
                   stats=
                       new List<KeyValuePair<string, int>>()
                       {
                           new KeyValuePair<string, int>( "Strength", 2000 ),
                           new KeyValuePair<string, int>( "Intelligence", 1000),
                           new KeyValuePair<string, int>( "Stamina", 2500 )
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
        public Hero Post(Hero hero, string value = "none")
        {
            //Added Post Logic To Evolve a 'Hero'
            if (hero.action.ToLower() == "action")
            {
                value = "action";
            }


            if (value == "action")
            {
                hero.evolve(0.5);
            }
              

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
