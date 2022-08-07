using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        private string _name { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                this._name = value;
            }
        }
        private string _power { get; set; }
        public string Power { 
            get { return _power; } 
            set { 
                this._power = value; 
            } 
        }
        private List<KeyValuePair<string, int>> _stats {get;set;}
        public List<KeyValuePair<string, int>> Stats
        {
            get { return _stats; }
            set
            {
                this._stats = value;
            }
        }

        public void evolve(int statIncrease = 5)
        {
            
        }

        public void Evolve(int statIncrease = 0)
        {
            List<KeyValuePair<string, int>> newList = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> level in Stats.ToList())
            {
                KeyValuePair<string,int> newEntry;
                if (statIncrease > 0)
                {
                    newEntry = new KeyValuePair<string, int>(level.Key, level.Value + statIncrease);
                }
                else
                {
                    newEntry = new KeyValuePair<string, int>(level.Key, level.Value + (level.Value/2));
                }
                newList.Add(newEntry);
                
            }
            _stats = newList;
        }
    }
}
