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
        private IHero[] heroes = new Hero[] {
               new Hero()
               {
                   name= "Hulk",
                   power="Strength from gamma radiation",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 ),
                   }

               },
                new Hero()
               {
                   name= "Superman",
                   power="Strength from gamma radiation",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength1", 15000 ),
                       new KeyValuePair<string, int>( "intelligence1", 20000),
                       new KeyValuePair<string, int>( "stamina1", 17000 ),
                   }

               },
            };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<IHero> Get()
        {
            return this.heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public IHero Get(int id)
        {
            return heroes.FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost("{act=none}")]
        public IEnumerable<IHero> Post(string action, string name)
        {
                switch (action?.ToLower())
                {
                    case "none":
                    default:
                        break;
                    case "evolve":
                        IHero hero = heroes.Where(h => h.name == name).FirstOrDefault();
                        hero?.evolve();
                        break;
            }
            return heroes;
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
