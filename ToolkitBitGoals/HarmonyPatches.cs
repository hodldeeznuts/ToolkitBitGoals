using HarmonyLib;
using RimWorld;
using System;
using Verse;

namespace ToolkitBitGoals
{
    [StaticConstructorOnStartup]
    internal static class HarmonyPatches
    {
        private static readonly Type patchType = typeof(HarmonyPatches);

        static HarmonyPatches()
        {
            Harmony harmony = new Harmony("com.rimworld.mod.hodlhodl.toolkit.bitgoals");

            harmony.Patch(
                original: AccessTools.Method(
                    type: typeof(MapInterface),
                    name: "MapInterfaceOnGUI_BeforeMainTabs"),
                postfix: new HarmonyMethod(typeof(BitGoalGUI), nameof(BitGoalGUI.DisplayCounter))
            );
        }
    }
}