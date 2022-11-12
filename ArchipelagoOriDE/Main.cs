using System;
using OriForestArchipelago.Events;
using OriForestArchipelago.Patches;
using UnityModManagerNet;
using OriForestArchipelago.Settings;
using UnityEngine;

namespace OriForestArchipelago
{
    public class Main
    {
        public static ModSettings CurrentModSettings;
        public static MainPatcher MainPatcher;
        public static MessageQueue MessageQueue;
        
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
            MessageQueue = new MessageQueue();

            GameStateChangeEventCheck.GameStateChangeEvent += EventHandler.OnStateChanged;
            CharacterSwitchedEventCheck.CharacterSwitchedEvent += EventHandler.OnCharacterSwitched;
            
            MainPatcher = new MainPatcher();
            MainPatcher.Patch();
            
            modEntry.OnSaveGUI += OnSaveGUI;
            modEntry.OnGUI += OnGUI;
            return true;
        }

        static void OnGUI(UnityModManager.ModEntry modEntry)
        {
            CurrentModSettings.Draw(modEntry);
            
            GUILayout.Space(7f);
            GUILayout.Label("Slot");
            CurrentModSettings.RandomizerSettings.Slot = 
                GUILayout.Toolbar(CurrentModSettings.RandomizerSettings.Slot, new GUIContent[]
                {
                    new GUIContent("Slot 1"),
                    new GUIContent("Slot 2"),
                    new GUIContent("Slot 3"),
                    new GUIContent("Slot 4"),
                    new GUIContent("Slot 5"),
                    new GUIContent("Slot 6"),
                    new GUIContent("Slot 7"),
                    new GUIContent("Slot 8"),
                    new GUIContent("Slot 9"),
                    new GUIContent("Slot 10")
                });
            
            GUILayout.Space(5f);
            //GUILayout.Label("Enabled");
            CurrentModSettings.RandomizerSettings.ArchipelagoSlots[CurrentModSettings.RandomizerSettings.Slot].Enabled = 
                GUILayout.Toggle(CurrentModSettings.RandomizerSettings.ArchipelagoSlots[CurrentModSettings.RandomizerSettings.Slot].Enabled, " Archipelago is " + ((CurrentModSettings.RandomizerSettings.ArchipelagoSlots[CurrentModSettings.RandomizerSettings.Slot].Enabled) ? "enabled": "disabled") + " in the current Slot");
            
            GUILayout.Space(5f);
            GUILayout.Label("Hostname");
            CurrentModSettings.RandomizerSettings.ArchipelagoSlots[CurrentModSettings.RandomizerSettings.Slot].Host = 
                GUILayout.TextField(CurrentModSettings.RandomizerSettings.ArchipelagoSlots[CurrentModSettings.RandomizerSettings.Slot].Host, GUILayout.Width(300f));

            GUILayout.Space(5f); 
            GUILayout.Label("Username");
            CurrentModSettings.RandomizerSettings.ArchipelagoSlots[CurrentModSettings.RandomizerSettings.Slot].User =
                GUILayout.TextField(CurrentModSettings.RandomizerSettings.ArchipelagoSlots[CurrentModSettings.RandomizerSettings.Slot].User, GUILayout.Width(300f));
            
            GUILayout.Space(5f); 
            GUILayout.Label("Password");
            CurrentModSettings.RandomizerSettings.ArchipelagoSlots[CurrentModSettings.RandomizerSettings.Slot].Password =
                GUILayout.PasswordField(CurrentModSettings.RandomizerSettings.ArchipelagoSlots[CurrentModSettings.RandomizerSettings.Slot].Password, '*', GUILayout.Width(300f));
        }

        static void OnSaveGUI(UnityModManager.ModEntry modEntry)
        {
            CurrentModSettings.Save(modEntry);
        }
        
    }
}