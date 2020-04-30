using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ToolkitBitGoals
{
    public class ToolkitBitGoalsSettings : ModSettings
    {
        public static int bitGoal = 100;

        static bool devMode = false;

        static int bitsToAddToGoal = 0;

        public void DoWindowContents(Rect inRect)
        {
            Listing_Standard listing = new Listing_Standard();
            listing.Begin(inRect);

            listing.Label("Input how many bits you want to set as a goal before your colony is raided.");

            string bitGoalBuffer = bitGoal.ToString();
            listing.TextFieldNumericLabeled("How many bits until you get raided", ref bitGoal, ref bitGoalBuffer, 1);

            listing.Gap();

            listing.ColumnWidth = inRect.width / 2;

            listing.CheckboxLabeled("Enable Dev Mode", ref devMode, "Use Dev Mode for testing or to fix a bug");

            if (devMode)
            {
                string bitsToAddBuffer = bitsToAddToGoal.ToString();
                listing.TextFieldNumericLabeled("Bits to Add", ref bitsToAddToGoal, ref bitsToAddBuffer);

                if (listing.ButtonText("Add Bits to Goal"))
                {
                    if (bitsToAddToGoal > 0 && Current.Game != null)
                    {
                        BitParser bitParser = Current.Game.GetComponent<BitParser>();

                        if (bitParser != null)
                        {
                            bitParser.currentBitCounter += bitsToAddToGoal;
                            bitParser.CheckIfCanRaid();
                        }
                    }
                }

                if (listing.ButtonText("Reset Bit Counter"))
                {
                    BitParser bitParser = Current.Game.GetComponent<BitParser>();

                    if (bitParser != null)
                    {
                        bitParser.currentBitCounter = 0;
                    }
                }
            }

            listing.End();
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref bitGoal, "bitGoal", 100);
        }
    }
}
