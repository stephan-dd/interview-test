using System.Collections.Generic;
using System.Linq;
using InterviewTest.Data;

using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeroesController : ControllerBase
    {
        private readonly HeroList _context;
        public HeroesController(HeroList context)
        {
            _context = context;
        }
        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _context.heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Hero> Get(int id)
        {
            return _context.heroes.FirstOrDefault(h => h.Id == id);
        }

        // POST: api/Heroes
        [HttpPost]
        public ActionResult<IEnumerable<Hero>> Post(int id, [FromBody] Hero hero, string action)
        {
            if (action == "evolve")
            {
                _context.heroes.FirstOrDefault(h => h.Id == id).evolve();
            }
            return _context.heroes;
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
