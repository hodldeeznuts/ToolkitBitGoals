using System.Collections.Generic;
using System.Linq;
using Verse;

namespace ToolkitBitGoals
{
    public static class RandomMap
    {
        public static Map GetRandomMap()
        {
            if (Current.Game == null || Current.Game.Maps == null)
                return null;
            else
            {
                List<Map> maps = Current.Game.Maps.Where(s => s.IsPlayerHome).ToList();
                maps.Shuffle();

                return maps.FirstOrDefault();
            }
        }
    }
}