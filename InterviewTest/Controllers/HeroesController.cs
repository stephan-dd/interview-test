using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        readonly IHero _repo;

        public HeroesController(IHero repo)
        {
            _repo = repo;
        }


        // GET: api/Heroes
        [HttpGet]
        public ActionResult<List<Hero>> GetHeroes()
        {
            return _repo.GetHero();

        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<List<Hero>> GetHeroess(int id)
        {
            return Ok(_repo.GetHeroById(id));
        }
        // POST: api/Heroes
        [HttpPost]
        public ActionResult<IEnumerable<Hero>> Post([FromQuery] string action = "none")
        {
            // did not catch errors
            List<Hero> heros = _repo.GetHero();
            if (action == "evolve")
            {
                
                for (int i = 0; i < heros.Count; i++)
                {
                    heros[i].evolve();
                }
            }

            return heros; 
           
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
