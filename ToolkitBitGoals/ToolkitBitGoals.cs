using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace ToolkitBitGoals
{
    public class ToolkitBitGoals : Mod
    {
        public ToolkitBitGoals(ModContentPack content) : base(content)
        {

        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            GetSettings<ToolkitBitGoalsSettings>().DoWindowContents(inRect);
        }
    }
}
