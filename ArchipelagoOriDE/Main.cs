using System;
using OriForestArchipelago.Events;
using UnityModManagerNet;
using OriForestArchipelago.Settings;
using UnityEngine;

namespace OriForestArchipelago
{
    public class Main
    {
        public static bool ModActive;

        public static ModSettings CurrentModSettings;
        
        public static GameStateChangeEventClass GameStateChangeEventCheck;
        public static CharacterSwitchedEventClass CharacterSwitchedEventCheck;

        public static UnityModManager.ModEntry.ModLogger Logger;
        
        // Send a response to the mod manager about the launch status, success or not.
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            Logger = modEntry.Logger;
            
            GameStateChangeEventCheck = new GameStateChangeEventClass();
            CharacterSwitchedEventCheck = new CharacterSwitchedEventClass();
            
            CurrentModSettings = ModSettings.Load<ModSettings>(modEntry);

            GameStateChangeEventCheck.GameStateChangeEvent += EventHandler.OnStateChanged;
            
            modEntry.OnSaveGUI = OnSaveGUI;
            modEntry.OnToggle = OnToggle;
            modEntry.OnGUI = OnGUI;
            return true;
        }
        
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value)
            {
                Console.WriteLine("Activated Archipelago Mod!");
            }
            else
            {
                Console.WriteLine("Deactivated Archipelago Mod!");
            }
            ModActive = value;
            return true;
        }

        static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            CurrentModSettings.Draw(modEntry);
        }

        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            CurrentModSettings.Save(modEntry);
        }
        
    }
}