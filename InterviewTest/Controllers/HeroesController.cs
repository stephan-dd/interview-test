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
        // Inject IHero Service to The Controller
        private readonly IHeroService _heroService;

        public HeroesController(IHeroService heroService)
        {
            _heroService = heroService;
        }        

        // GET: api/Heroes
        [HttpGet]
        public ActionResult<IEnumerable<Hero>> Get()
        {
            return Ok(_heroService.GetHeroList());
        }

        // GET: api/Heroes/hulk
        [HttpGet("{name}")]
        public ActionResult<Hero> GetByName(string name)
        {
            var hero = _heroService.GetHeroByName(name);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        // POST: api/Heroes/hulk/evolve
        [HttpPost]
        public ActionResult<Hero> Post([FromBody] EvolveRequest request)
        {
            if(request.UserAction.Equals("evolve", System.StringComparison.CurrentCultureIgnoreCase))
            {
                var heroes = _heroService.Evolve(request.HeroName);
                if (heroes == null)
                {
                    return BadRequest("Failed to evolve");
                }
                return Ok(heroes);
            }
            return BadRequest("Only for evolve action");
        }
    }
    public class EvolveRequest
    {
        public string HeroName { get; set; }
        public string UserAction { get; set; } = "none";

    }
}
