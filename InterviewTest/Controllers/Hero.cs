using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewTest.Interfaces;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        private bool lastUpdated;
        private int id;
        private string name;
        private string power;
        private List<KeyValuePair<string, double>> stats;

        public bool LastUpdated
        {
            get { return lastUpdated; }
            set { lastUpdated = value; }

        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Power
        {
            get { return power; }
            set { power = value; }
        }
        public List<KeyValuePair<string, double>> Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public List<KeyValuePair<string, double>> Evolve(List<KeyValuePair<string, double>> heroStats)
        {
            var kvp = new List<KeyValuePair<string, double>>();

            foreach (var (key, value) in heroStats.AsEnumerable())
                kvp.Add(new KeyValuePair<string, double>(key, value * 1.5));

            stats.Clear();
            stats = kvp;
            return kvp;
        }
    }
}
