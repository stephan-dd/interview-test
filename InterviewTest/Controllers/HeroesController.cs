using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Interfaces;
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
                   name= "Captain America",
                   power="Strength from super soldier syrup",
                   stats=
                   new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 200 ),
                       new KeyValuePair<string, int>( "intelligence", 2),
                       new KeyValuePair<string, int>( "stamina", 25 )
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
        //Updated this method to take parameter  action
        public IActionResult Post([FromBody] string value, [System.Web.Http.FromUri] string action= "none")
        {
            MapHero(value);
            //if the action is evolve it should evolve the hero and return the hero with its new stats.
            if (action == "evolve")
            {
               _hero.evolve();
                return Ok(_hero);
            }
            return Ok();
        }
        void MapHero(string value)
        {
            var hero = heroes.Where(x => x.name == value).FirstOrDefault();
            _hero.name = hero.name;
            _hero.power = hero.power;
            _hero.stats = hero.stats;
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
