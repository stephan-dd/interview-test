using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private IHero[] heroes = new Hero[] {
               new Hero()
               {
                   Name= "Hulk",
                   Power="Strength from gamma radiation",
                   Stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 ),
                   }

               },
                new Hero()
               {
                   Name= "Superman",
                   Power="Strength from sun exposure",
                   Stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 15000 ),
                       new KeyValuePair<string, int>( "intelligence", 20000),
                       new KeyValuePair<string, int>( "stamina", 17000 ),
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
        public IEnumerable<IHero> Post(string action, string hero)
        {
                switch (action?.ToLower())
                {
                    case "none":
                    default:
                        break;
                    case "evolve":
                        IHero SelectedHero = heroes.Where(k => k.Name == hero).FirstOrDefault();
                        SelectedHero?.Evolve();
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
