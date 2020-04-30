using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolkitCore;
using TwitchLib.Client.Models.Interfaces;
using Verse;

namespace ToolkitBitGoals
{
    public class BitParser : TwitchInterfaceBase
    {
        public BitParser(Game game)
        {

        }

        public override void ParseMessage(ITwitchMessage twitchMessage)
        {
            if (twitchMessage.ChatMessage.Bits > 0)
            {
                currentBitCounter += twitchMessage.ChatMessage.Bits;

                CheckIfCanRaid();
            }
        }

        public void CheckIfCanRaid()
        {
            if (currentBitCounter >= ToolkitBitGoalsSettings.bitGoal)
            {
                currentBitCounter = currentBitCounter - ToolkitBitGoalsSettings.bitGoal;

                Map map = RandomMap.GetRandomMap();

                IncidentWorker_RaidEnemy raid = new IncidentWorker_RaidEnemy
                {
                    def = IncidentDefOf.RaidEnemy,
                };

                IncidentParms parms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, map);

                raid.TryExecute(parms);
            }
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref currentBitCounter, "currentBitCounter", 0);
        }

        public int currentBitCounter = 0;
    }
}
