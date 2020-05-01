using RimWorld;
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
                currentBitCounter -= ToolkitBitGoalsSettings.bitGoal;

                Map map = RandomMap.GetRandomMap();

                IncidentParms incidentParms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.ThreatBig, map);
                IncidentDefOf.RaidEnemy.Worker.TryExecute(incidentParms);
            }
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref currentBitCounter, "currentBitCounter", 0);
        }

        public int currentBitCounter = 0;
    }
}