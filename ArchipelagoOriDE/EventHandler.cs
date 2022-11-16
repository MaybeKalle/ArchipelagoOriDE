using System;
using Game;
using OriForestArchipelago.Network;
using OriForestArchipelago.Settings;
using UnityEngine;

namespace OriForestArchipelago
{
    public class EventHandler
    {
        public static void OnStateChanged(GameStateMachine.State state)
        {
            if (state == GameStateMachine.State.Game)
            {
                int slot = GameController.Instance.SaveGameController.CurrentSlotIndex;
                ArchipelagoSlotSettings settings = Main.CurrentModSettings.RandomizerSettings.ArchipelagoSlots[slot];
                if (settings.Enabled)
                {
                    Main.Logger.Log("Detected an Archipelago-enabled save [Slot " + (slot + 1) + "]...");
                    State.ArchipelagoSlot = true;

                    Main.RandomizerSession = new RandomizerSession(settings.Host);
                    Main.RandomizerSession.Connect(settings.User);
                } 
                else
                {
                    State.ArchipelagoSlot = true;
                }
            }
        }

        public static void OnCharacterSwitched(bool ingame, string character, SeinCharacter seinCharacter)
        {
            if (seinCharacter != null) State.SeinCharacter = seinCharacter;
        }
    }
}