using System;
using System.Collections.Generic;

namespace InterviewTest.Data
{
    public class Hero
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats {get;set;}
        public void evolve(List<KeyValuePair<string, int>> originalStats)
        {
            var newStats = new List<KeyValuePair<string, int>>();
            foreach (var kv in stats)
            {
                var originalVal = 0;
                foreach (var kvPair in originalStats)
                    if (kvPair.Key == kv.Key)
                        originalVal = kvPair.Value;

                newStats.Add(new KeyValuePair<string, int>(kv.Key, Convert.ToInt32((originalVal * 0.5) + kv.Value)));
            }
                
            stats = newStats;
        }
    }
}
