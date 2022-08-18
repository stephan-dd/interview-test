using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Models;
using InterviewTest.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHeroService _service;

        public HeroesController(IHeroService service)
        {
            _service = service;
        }

        // GET: api/Heroes
        [HttpGet]
        public List<Hero> Get()
        {
            return _service.GetHeroes();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public IHero Get(int id)
        {
            return _service.GetHeroes().FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public ActionResult<List<KeyValuePair<string, int>>> Post([FromQuery] string action = "none")
        {
            // MJK: API part of test just using action on the first hero
            try
            {
                if (action.Equals("evolve", StringComparison.CurrentCultureIgnoreCase))
                {
                    var hero = _service.GetHeroes().FirstOrDefault();
                    hero.evolve();
                    _service.Update(hero);
                    return Ok(hero);
                }
                else
                {
                    return BadRequest(new { message = "Invalid action." });
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
       
        }

        [HttpPost("{heroname}")]
        public ActionResult<List<KeyValuePair<string, int>>> Post([FromRoute] string heroname = "", [FromQuery] string action = "none")
        {
            // MJK: For the frontend part where the Hero name is also needed
            try
            {
                if (action.Equals("evolve", StringComparison.CurrentCultureIgnoreCase))
                {
                    var hero = _service.GetHeroes().FirstOrDefault(_=>_.name.Equals(heroname,StringComparison.CurrentCultureIgnoreCase));
                    if (hero != null)
                    {
                        hero.evolve();
                        _service.Update(hero);
                        return Ok(hero);
                    }
                    else
                    {
                        return BadRequest(new { message = "Unknown hero." });
                    }
                }
                else
                {
                    return BadRequest(new { message = "Invalid action." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
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
