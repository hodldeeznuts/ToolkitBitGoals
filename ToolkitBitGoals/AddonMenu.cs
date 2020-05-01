using System.Collections.Generic;
using ToolkitCore.Interfaces;
using ToolkitCore.Windows;
using Verse;

namespace ToolkitBitGoals
{
    public class AddonMenu : IAddonMenu
    {
        List<FloatMenuOption> IAddonMenu.MenuOptions() => new List<FloatMenuOption>
        {
            new FloatMenuOption("Settings", delegate ()
            {
                Window_ModSettings window = new Window_ModSettings(LoadedModManager.GetMod<ToolkitBitGoals>());
                Find.WindowStack.TryRemove(window.GetType());
                Find.WindowStack.Add(window);
            })
        };
    }
}