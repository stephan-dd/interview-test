using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Interfaces;
using InterviewTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("heroes")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private IHero _hero;
        public HeroesController(IHero hero)
        {
            _hero = hero;
        }

        //Evolve the hero
        [HttpPost("evolve")]
        public HeroAttributes Post([FromBody] HeroAction ha)
        {
            if (ha.action == "evolve")
            {
                var result = _hero.evolve(ha.hero);
                return result;

            } else
            {
                return null;
            }

        }

        [HttpGet]
        public IEnumerable<HeroAttributes> Get()
        {
            return _hero.getHeroes();
        }

    }
}
