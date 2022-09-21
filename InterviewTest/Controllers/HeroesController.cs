namespace InterviewTest.Controllers
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using InterviewTest.Controllers.Data;
    using InterviewTest.Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    #endregion //Using Directives

    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        #region Constructors

        public HeroesController(HeroCache cache)
        {
            _cache = cache;
        }

        #endregion //Constructors

        #region Fields

        private HeroCache _cache;

        #endregion //Fields

        #region Action Methods

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return _cache.GetAll();
        }

        //GET: api/Heroes/5
        [HttpGet("{name}", Name = "Get")]
        public Hero Get(string name)
        {
            return _cache.Get(name, throwExceptionOnNotFound: false);
        }

        [HttpPost("{actionToPerform?}")]
        public Hero Post([FromBody] Hero hero, string actionToPerform = "none")
        {
            if (hero == null)
            {
                throw new Exception($"No {nameof(Hero)} provided to be updated.");
            }
            if (actionToPerform.Trim().ToLower().Equals("evolve"))
            {
                hero.evolve();
            }
            _cache.Add(hero);
            return hero;
        }

        // PUT: api/Heroes/5
        [HttpPut("{actionToPerform?}")]
        public Hero Put([FromBody] Hero hero, string actionToPerform = "none")
        {
            if (hero == null)
            {
                throw new Exception($"No hero provided to be updated.");
            }
            Hero originalHero = _cache.Get(hero.name, throwExceptionOnNotFound: true);
            bool evolve = actionToPerform.Trim().ToLower().Equals("evolve");
            if (evolve)
            {
                originalHero.evolve();
            }
            originalHero.CopyFrom(hero, copyStats: !evolve);
            return originalHero;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public bool Delete(string name)
        {
            return _cache.Delete(name, throwExceptionOnNotFound: true);
        }

        #endregion //Action Methods
    }
}
