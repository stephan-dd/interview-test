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
        #region Action Methods

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return HeroCache.Instance.GetAll();
        }

        //GET: api/Heroes/5
        [HttpGet("{name}", Name = "Get")]
        public Hero Get(string name)
        {
            return HeroCache.Instance.Get(name, throwExceptionOnNotFound: false);
        }

        [HttpPost("{actionToPerform?}")]
        public Hero Post([FromBody] Hero hero, string actionToPerform = "none")
        {
            if (hero == null)
            {
                throw new Exception($"No hero provided to be updated.");
            }
            if (actionToPerform.Trim().ToLower().Equals("evolve"))
            {
                hero.evolve();
            }
            HeroCache.Instance.Add(hero);
            return hero;
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public void Put([FromBody] Hero hero)
        {
            if ((hero == null))
            {
                throw new Exception($"No hero provided to be updated.");
            }
            Hero originalHero = HeroCache.Instance.Get(hero.name, throwExceptionOnNotFound: true);
            originalHero.CopyFrom(hero);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{name}")]
        public bool Delete(string name)
        {
            return HeroCache.Instance.Delete(name, throwExceptionOnNotFound: true);
        }

        #endregion //Action Methods
    }
}
