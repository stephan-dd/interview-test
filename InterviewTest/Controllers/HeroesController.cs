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
        private readonly IHero _hero;
        private Hero[] heroes = new Hero[] {
               new Hero()
               {
                   name= "Hulk0",
                   power="Strength from stars",
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
                   name= "Hulk1",
                   power="Strength from snow",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 3000 ),
                       new KeyValuePair<string, int>( "intelligence", 40),
                       new KeyValuePair<string, int>( "stamina", 3500 )
                   }
               },
               new Hero()
               {
                   name= "Hulk2",
                   power="Strength from hot water",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 4000 ),
                       new KeyValuePair<string, int>( "intelligence", 70),
                       new KeyValuePair<string, int>( "stamina", 3500 )
                   }
               },
               new Hero()
               {
                   name= "Hulk3",
                   power="Strength from gamma radiation",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 10000 ),
                       new KeyValuePair<string, int>( "intelligence", 150),
                       new KeyValuePair<string, int>( "stamina", 4300 )
                   }
               }
            };
        public HeroesController(IHero hero)
        {
            _hero = hero;
        }
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
        public Hero Post(HeroAction action)
        {
            var hero = heroes.Where(x => x.name == action.name).FirstOrDefault();
            var heroStats = new List<KeyValuePair<string, int>>();
            if (action.action == "evolve" && hero != null)
            {
                foreach (var item in hero.stats)
                {
                    int newStatValue = _hero.evolve(item.Value);
                    var newStat = new KeyValuePair<string, int>(item.Key, newStatValue);
                    heroStats.Add(newStat);
                }
                hero.stats = heroStats;
            }
           
            return hero;
        }

        // POST: api/Heroes
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

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
