using System;
using UnityEngine;
using UnityModManagerNet;

namespace OriForestArchipelago.Settings
{
    public class ModSettings : UnityModManager.ModSettings, IDrawable
    {
        public ArchipelagoSettings RandomizerSettings = new ArchipelagoSettings();
        
        public DebugSettings DebugSettings = new DebugSettings();

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }

        public void OnChange()
        {
        }
    }
}