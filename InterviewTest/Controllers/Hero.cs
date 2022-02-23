using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Interfaces;

namespace InterviewTest.Controllers
{
    public class Hero:IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public List<KeyValuePair<string, int>> statsNew { get; set; }

        //Evolve POST only works in POSTMAN once.
        public void evolve(int statIncrease = 5)
        {
            KeyValuePair<string, int> newEntry = new KeyValuePair<string, int>();
            statsNew = new List<KeyValuePair<string, int>>();

            //Loop through each stat
            foreach (var stat in stats)
            {
                var halfValue = stat.Value / 2; //Divide current stat into half
                var newStatValue = stat.Value * halfValue; //Multiply halved value to original value
                var statIncreasedValue = newStatValue.ToString(); //Set to string variable
                newEntry =  new KeyValuePair<string, int>(stat.Key, Convert.ToInt32(statIncreasedValue));
                statsNew.Add(newEntry);//Add to new list to reflect changes
            }
        }
    }
}
