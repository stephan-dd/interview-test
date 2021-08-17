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
                   Name= "Iron man",
                   Power="Man of steel",
                   Stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 1500 ),
                       new KeyValuePair<string, int>( "intelligence", 2000),
                       new KeyValuePair<string, int>( "stamina", 2500 )
                   }
               }
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
            return this.heroes.FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost("{name}/{act=none}/{statIncrease:int=1}")]
        public IHero Post(string name, string act, int statIncrease)
        {
            IHero hero = heroes.Where(h => h.Name == name).FirstOrDefault();
            if (hero != null)
            {
                switch (act.ToLower())
                {
                    case "evolve":
                        hero.Evolve(statIncrease);
                        break;
                    case "none":
                    default:
                        // Do nothing;
                        break;
                }
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
