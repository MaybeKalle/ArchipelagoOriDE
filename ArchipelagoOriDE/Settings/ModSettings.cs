using System;
using UnityEngine;
using UnityModManagerNet;

namespace OriForestArchipelago.Settings
{
    public class ModSettings : UnityModManager.ModSettings, IDrawable
    {
        [Draw("Use Archipelago")] public bool EnableRandomizer = true;
        public ArchipelagoSettings RandomizerSettings = new ArchipelagoSettings();

        [Draw("Please copy the provided Settings.xml into your Mods folder.")] public string note;

        public override void Save(UnityModManager.ModEntry modEntry)
        {
            Save(this, modEntry);
        }

        public void OnChange()
        {
        }
    }
}