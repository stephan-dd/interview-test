using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Models
{
    public class Hero : IHero
    {
        [Key]
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }
        public void evolve(int statIncrease = 5)
        {
            // MJK: KeyValuePairs are immutable so we cannot change the values lets make a new List to replace the stats.
            List<KeyValuePair<string, int>> tmp = new List<KeyValuePair<string, int>>(stats.Count);
            foreach ( var item in stats)
            {
                tmp.Add(new KeyValuePair<string, int>(item.Key, item.Value + (item.Value / 2) * statIncrease));
            }

            stats = tmp;
        }

    }
}
