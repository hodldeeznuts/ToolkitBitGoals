using UnityEngine;
using Verse;

namespace ToolkitBitGoals
{
    public class ToolkitBitGoals : Mod
    {
        public ToolkitBitGoals(ModContentPack content) : base(content)
        {
            GetSettings<ToolkitBitGoalsSettings>();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            GetSettings<ToolkitBitGoalsSettings>().DoWindowContents(inRect);
        }
    }
}