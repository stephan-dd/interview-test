using System.Collections.Generic;
using System.Linq;
using InterviewTest.Data;
using System;

using Microsoft.AspNetCore.Mvc;
using InterviewTest.Interface;

namespace InterviewTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly IHero _hero;
        public HeroesController(IHero context)
        {
            _hero = context;
        }
        // GET: api/Heroes
        [HttpGet]
        public List<Hero> Get()
        {
            return _hero.Heroes();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Hero> Get(int id)
        {
            return _hero.Heroes().FirstOrDefault(h => h.Id == id);
        }

        // POST: api/Heroes
        [HttpPost]
        public ActionResult<IEnumerable<Hero>> Post([FromBody] Hero hero, [FromQuery] string action = "none")
        {
            if (action == "evolve")
            {
                hero.evolve();
            }
            return _hero.Heroes();
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
