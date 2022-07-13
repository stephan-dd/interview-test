using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        private string HeroName { get; set; }
        private string HeroPower { get; set; }  
        private List<KeyValuePair<string, int>> HeroStats { get; set; }

        public string Name 
        { 
            get { return HeroName; } 
            set { this.HeroName = value; } 
        }
        public string Power 
        {
            get { return HeroPower; }
            set { this.HeroPower = value; }
        }
        public List<KeyValuePair<string, int>> Stats 
        {
            get { return HeroStats; }
            set { this.HeroStats = value; }
        }
        public void Evolve(int statIncrease = 5)
        {
            var count = 2.5;
            foreach (KeyValuePair<string, int> kvp in Stats) 
            {
                count++;
            }
        }
    }
}
