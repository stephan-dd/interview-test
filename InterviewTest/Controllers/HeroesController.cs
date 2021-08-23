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
      
        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<IHero> Get()
        {
            return Heroes.GetHeroes();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public IHero Get(int id)
        {
            return Heroes.GetHeroes().FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost("{name}/{act=none}/{statIncrease:int=1}")]
        public IHero Post(string name, string act, int statIncrease)
        {
            IHero hero = Heroes.GetHeroes().Where(h => h.Name == name).FirstOrDefault();
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
