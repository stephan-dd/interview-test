using System.Collections.Generic;

namespace InterviewTest.Models
{
    interface IHero
    {
      void Evolve();
    }

    public class Hero: IHero
    {
        public  int HeroId { get; set; }
        public string Name { get; set; }
        public string Power { get; set; }
        public List<KeyValuePair<string, int>> Stats {get;set;}
        public void Evolve()
        {
          var ModifiedStats = new List<KeyValuePair<string, int>>();

          Stats.ForEach(c =>
          {
            ModifiedStats.Add(new KeyValuePair<string, int>(c.Key, c.Value + (c.Value / 2)));
          });

        Stats.Clear();
        Stats.AddRange(ModifiedStats);

        }
    }
}
