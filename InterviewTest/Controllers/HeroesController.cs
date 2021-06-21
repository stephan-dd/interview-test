using InterviewTest.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly Repository.IHeroRepository heroRepository;

        public HeroesController(Repository.IHeroRepository heroRepository)
        {
            this.heroRepository = heroRepository ?? throw new ArgumentNullException(nameof(heroRepository));
        }

        // GET: api/Heroes
        [HttpGet]
        public ActionResult<IEnumerable<IHero>> Get()
        {
            return Ok(heroRepository.GetHeroes());
        }

        // GET: api/Heroes/{name}
        [HttpGet("{name}", Name = "Get")]
        public ActionResult<IHero> Get(string name)
        {
            IHero hero = heroRepository.GetHero(name);

            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        // POST: api/Heroes/{name}
        [HttpPost("{name}")]
        public ActionResult<IHero> Post(
            string name,
            [FromQuery][Required(ErrorMessage = "Value cannot be empty or null")] string value="none")
        {
            const string evolveParam = "evolve";

            IHero hero = heroRepository.GetHero(name);

            if (hero == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(value) && evolveParam.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                hero.Evolve();
            }

            return Ok(hero);
        }

        // PUT: api/Heroes
        [HttpPut]
        public ActionResult Put([FromBody] Hero hero)
        {
            if (heroRepository.CheckHeroExists(hero.Name))
            {
                if (!heroRepository.UpdateHero(hero))
                {
                    return StatusCode((int)System.Net.HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                heroRepository.AddHero(hero);
            }

            return Ok();
        }

        // DELETE: api/Heroes/{name}
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            if (!heroRepository.CheckHeroExists(name))
            {
                return NotFound();
            }

            if (!heroRepository.DeleteHero(name))
            {
                return StatusCode((int)System.Net.HttpStatusCode.InternalServerError);
            }

            return Ok();
        }
    }
}