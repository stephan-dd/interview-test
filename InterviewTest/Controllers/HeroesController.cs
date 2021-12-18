using System.Collections.Generic;
using System.Linq;
using InterviewTest.Models;
using InterviewTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly IHero _heroRepository;

        public HeroesController(IHero heroRepository)
        {
            _heroRepository = heroRepository;
        }

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _heroRepository.GenerateHeroData().AsEnumerable();
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id)
        {
            return _heroRepository.GenerateHeroData().FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public Hero Post(int statIncrease, string hero, [FromBody]string value = "none")
        {
            Hero heroData = _heroRepository.GenerateHeroData().FirstOrDefault(x => x.Name.Equals(hero));
            if (value == "evolve")
            {
                _heroRepository.Evolve(heroData, statIncrease);
            }
            return heroData;
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
