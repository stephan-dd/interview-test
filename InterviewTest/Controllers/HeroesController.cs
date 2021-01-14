using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace InterviewTest.Controllers
{
    //[Route("api/[controller]")]
    [Route("heroes")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private Hero[] heroes = new Hero[] {
           new Hero()
            {
                 name= "Hulk",
                 power="Strength from gamma radiation",
                  stats=new List<KeyValuePair<string, int>>()
                  {
                      new KeyValuePair<string, int>( "strength", 5000 ),
                      new KeyValuePair<string, int>( "intelligence", 50),
                      new KeyValuePair<string, int>( "stamina", 2500 )
                  }
   
           },
           new Hero()
           {
               name= "Mbinga",
               power="Serious money supply",
               stats=new List<KeyValuePair<string, int>>()
               {
                      new KeyValuePair<string, int>( "strength", 7000 ),
                      new KeyValuePair<string, int>( "intelligence", 65),
                      new KeyValuePair<string, int>( "stamina", 2000 )
               }
           },

           new Hero()
           {
               name= "Musoro Bhangu",
               power= " Thinker par excellence",
               stats=new List<KeyValuePair<string,int>>()
               {
                      new KeyValuePair<string, int>( "strength", 2000 ),
                      new KeyValuePair<string, int>( "intelligence", 205),
                      new KeyValuePair<string, int>( "stamina", 1500 )

               }
           }
        };
        private Hero theone;


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
        ///public IEnumerable<Hero> Post([FromBody] string value)
        public Hero Post([FromQuery] string action, [FromQuery] string theHero)
        {
            if(action=="evolve")
            {
                var theone = this.heroes.Where( _h => _h.name == theHero ).FirstOrDefault();                  
                theone.evolve();
                return theone;
            }else
            {
                return null;
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
