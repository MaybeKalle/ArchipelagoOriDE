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
                if (settings.Enabled && !(Main.RandomizerSession != null && Main.RandomizerSession.IsConnected()))
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
            else if (Main.RandomizerSession != null &&
                     (state == GameStateMachine.State.StartScreen || state == GameStateMachine.State.TitleScreen) &&
                     Main.RandomizerSession.IsConnected())
            {
                Main.RandomizerSession.Disconnect();
                Main.RandomizerSession = null;
                Main.MessageQueue.Clear();
                Main.Logger.Log("Disconnected from Archipelago server.");
            }
        }

        public static void OnCharacterSwitched(bool ingame, string character, SeinCharacter seinCharacter)
        {
            if (seinCharacter != null)
            {
                State.Ingame = true;
                State.SeinCharacter = seinCharacter;
            }
            else
            {
                State.SeinCharacter = null;
                State.Ingame = false;
            }
        }
    }
}