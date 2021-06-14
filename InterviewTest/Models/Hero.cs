using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public string Name { get; set; }
        public string Power { get; set; }
        public List<KeyValuePair<string, int>> Stats {get;set;}
        public void Evolve(int statIncrease = 5)
        {
            //## API (C#)
            //            *Refactor the Hero class to implement an interface of IHero.
            //           * The `evolve` method on the class should increment all stats of the hero with a multiple of half the original stat value.
            //           * The `post` method should read an `action` parameter which defaults to `none`
            //if the action is evolve it should evolve the hero and return the hero with its new stats.
            var newKeyValue = new List<KeyValuePair<string, int>>();
            this.Stats.ForEach(stat => {
                var halfOrigivalValue = stat.Value / 2;

                var newValue = stat.Value + halfOrigivalValue;

                newKeyValue.Add(new KeyValuePair<string, int>(stat.Key, newValue));
            });
            Stats = newKeyValue;
        }
    }
}
