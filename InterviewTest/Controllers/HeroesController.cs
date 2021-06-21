using System.Collections.Generic;
using System.Linq;
using InterviewTest.Data;
using InterviewTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHero _hero;

        public HeroesController(IHero hero)
        {
            _hero = hero;
        }

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get() => _hero.GetHeroes();

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id) => _hero.GetHeroes().FirstOrDefault(x => x.Id == id);

        // POST: api/Heroes?action=none
        [HttpPost]
        public Hero Post([FromBody] Hero dto, [FromQuery] string action = "none")
        {
            if (action.ToLower() == "evolve")
                dto.evolve(_hero.GetHeroes().First(x => x.Id == dto.Id).stats);

            return dto;
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
