using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Models;
using InterviewTest.Services;
using Microsoft.AspNetCore.Http;
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
        public IEnumerable<HeroModel> Get()
        {
            var heroes = _hero.GetHeroes();

            return heroes;
        }

        // GET: api/Heroes/getby/hero/5
        [HttpGet("getby/hero/{id}", Name = "Get")]
        public HeroModel Get(int id)
        {
            var hero = _hero.GetById(id);

            return hero;
        }

        // POST: api/Heroes/evolveby/hero/name
        [HttpPost("evolveby/hero/{name}")]
        public HeroModel Post(string name, [FromBody] string action = "none")
        {
            var hero = _hero.Evolve(name, action, 5);

            return hero;
        }
    }
}
