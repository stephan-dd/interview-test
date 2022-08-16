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
                   id = '1'
                   name= "Hulk",
                   power="Strength from gamma radiation",
                   stats= new List<KeyValuePair<string, int>>()
                   {
                       new KeyValuePair<string, int>( "strength", 5000 ),
                       new KeyValuePair<string, int>( "intelligence", 50),
                       new KeyValuePair<string, int>( "stamina", 2500 )
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
        public void Post([FromBody] string value)
        {
            //The `post` method should read an `action` parameter which defaults to `none`if the action is evolve it should evolve the hero and return the hero with its new stats.
            Hero Obj = new Hero();

            Obj.stats = hero.stats;

            Obj.evolve();

            hero.stats = Obj.stats;

            return hero;

        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //The `post` method should read an `action` parameter which defaults to `none` if the action is evolve it should evolve the hero and return the hero with its new stats.
            Hero Obj = new Hero();

            Obj.stats = hero.stats;

            Obj.evolve();

            hero.stats = Obj.stats;

            return hero;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
