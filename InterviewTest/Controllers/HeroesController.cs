using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    //delegate void Action(PostActionEnum enumVal);

    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private Hero[] heroes = new Hero[] { };

        public HeroesController()
        {
            heroes = Helper.GetHeroesFromXml();
        }
       

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return this.heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id)
        {
            return this.heroes.FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        //
        //public void Post(int? id, Action<string> action = null)
        public void Post(PostData data)
        {

            if (data.Action != null && data.Id.HasValue)
                if (data.Action.ToString().ToLower().Equals("evolve"))
                    if (heroes.Length - 1 >= data.Id)
                    {
                        Hero hero = new Hero();
                        hero = this.heroes[data.Id.Value];
                        hero.Stats = hero.Evolve(hero.Stats);
                        foreach (var heroItem in this.heroes)
                            heroItem.LastUpdated = false;
                        hero.LastUpdated = true;
                        Helper.UpdateHeroStats(hero);
                        heroes[data.Id.Value] = hero;
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
    public class PostData
    {
        public int? Id { get; set; }
        public string Action { get; set; }
    }
}
