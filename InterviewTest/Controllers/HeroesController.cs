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
        // injects hero and helper interface 
        private readonly IHero _hero;
        private readonly IHeroUtilities _heroUtilities;

        public HeroesController(IHero hero, IHeroUtilities statsConfig)
        {
            _heroUtilities = statsConfig;
            _hero = hero;
        }

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _heroUtilities.GetHeroes();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id)
        {
            return _heroUtilities.GetHeroes().FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public Hero Post([FromForm]string action)
        {
            if (action == "evolve")
            {
                return _hero.evolve(_heroUtilities.StatIncrease);
            }
            else
            {
                return _heroUtilities.GetHeroes().FirstOrDefault();
            }
             
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
