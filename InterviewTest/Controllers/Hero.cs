using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        
        private string name { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                this.name = value;
            }
        }

        private string power { get; set; }

        public string Power
        {
            get { return power; }
            set
            {
                this.power = value;
            }
        }

        private List<KeyValuePair<string, int>> stats {get;set;}

        public List<KeyValuePair<string, int>> Stats
        {
            get { return stats; }
            set
            {
                this.stats = value;
            }
        }

        public void evolve(int statIncrease = 5)
        {
            
        }

        public void Evolve(int statIncrease)
        {
            foreach (KeyValuePair<string, int> level in Stats)
            {
                
            }
        }
    }
}
