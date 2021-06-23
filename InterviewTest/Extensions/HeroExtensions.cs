using InterviewTest.Models;
using InterviewTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Extensions
{
    public static class HeroExtensions
    {
        public static IHero ApplyNewStatsToList(this IHero hero,Hero newHeroVals,HeroStats newStats)
        {
            foreach (var item in newHeroVals?.stats)
            {
                var removeIndex = hero.stats.FindIndex(kp => kp.Key == item.Key);
                hero.stats.RemoveAt(removeIndex);
                switch (item.Key)
                {
                    case "strength":
                        hero.stats.Add(new KeyValuePair<string, int>("strength", newStats?.Strength ?? 0));
                        break;
                    case "intelligence":
                        hero.stats.Add(new KeyValuePair<string, int>("intelligence", newStats?.Intelligence ?? 0));
                        break;
                    case "stamina":
                        hero.stats.Add(new KeyValuePair<string, int>("stamina", newStats?.Stamina ?? 0));
                        break;
                }

            }

            return hero;
        }
    }
}
