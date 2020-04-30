using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ToolkitBitGoals
{
    [StaticConstructorOnStartup]
    static class HarmonyPatches
    {
        private static readonly Type patchType = typeof(HarmonyPatches);

        static HarmonyPatches()
        {
            Harmony harmony = new Harmony("com.rimworld.mod.hodlhodl.toolkit.bitgoals");

            harmony.Patch(
                original: AccessTools.Method(
                    type: typeof(MapInterface),
                    name: "MapInterfaceOnGUI_BeforeMainTabs"),
                postfix: new HarmonyMethod(typeof(HarmonyPatches), nameof(BitGoalGUI))
            );
        }

        static void BitGoalGUI()
        {
            Rect rect = new Rect(UI.screenWidth - 360f, 10f, 360f, 28f);

            GameFont old = Text.Font;
            Text.Font = GameFont.Medium;

            BitParser bitParser = Current.Game.GetComponent<BitParser>();

            if (bitParser != null)
            {
                Widgets.Label(rect, $"<b><color=#8B0000>Current Bits</color></b>: {bitParser.currentBitCounter}/{ToolkitBitGoalsSettings.bitGoal}");
            }

            Text.Font = old;
        }
    }
}
