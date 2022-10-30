using System;
using Game;
using UnityEngine;

namespace OriForestArchipelago
{
    public class EventHandler
    {
        public static void OnStateChanged(GameStateMachine.State state)
        {
            Console.WriteLine("[Archipelago Debug] The game state changed to: " + state.ToString());
            if (state == GameStateMachine.State.Game)
            {
                Main.Logger.Log("Player opened save " + GameController.Instance.SaveGameController.CurrentSlotIndex);
            }
        }

        public static void OnCharacterSwitched(bool ingame, string character)
        {
            if(ingame) Console.WriteLine("[Archipelago Debug] The player took control of a character. (" + character + ")");
            if(!ingame) Console.WriteLine("[Archipelago Debug] The player lost control of all characters.");
        }
    }
}